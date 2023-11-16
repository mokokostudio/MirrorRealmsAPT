module MR::nft {
    use std::acl;
    use std::bcs;
    use std::hash;
    use std::option;
    use std::signer;
    use std::string;
    use std::vector;
    use aptos_std::from_bcs;
    use aptos_std::smart_table;
    use aptos_std::smart_vector;
    use aptos_std::string_utils;
    use aptos_framework::account;
    use aptos_framework::account::SignerCapability;
    use aptos_framework::event;
    use aptos_framework::object;
    use aptos_framework::timestamp;
    use MR::vec_set;

    use aptos_token_objects::collection;
    use aptos_token_objects::property_map;
    use aptos_token_objects::royalty;
    use aptos_token_objects::token;
    use aptos_token_objects::token::Token;


    const ESaleNotStarted: u64 = 10;
    const ESoldOut: u64 = 11;
    const EInvalidTokenOwner: u64 = 12;
    const ENotWhiteListAddress: u64 = 13;
    const EInsufficientNFTPool: u64 = 14;
    const EInsufficientWhiteNFTPool: u64 = 15;
    const EInvalidContartOwner: u64 = 16;
    const ENotPublicListAddress: u64 = 17;
    const EInsufficientPublicNFTPool: u64 = 18;
    const ETooManyWhiteListAddress: u64 = 19;
    const ETooManyPublicListAddress: u64 = 20;
    const ESaleStarted : u64 = 21;
    const EPublicListCountTooMany: u64 = 22;
    const EWhiteListCountTooMany: u64 = 23;
    const EWhiteListAddress: u64 = 24;

    const SEED: vector<u8> = b"MRWorldviewCard";
    const MaxCount : u64 = 1568;
    const CollectionName: vector<u8> = b"MRWorldviewCard";
    const CollectionDescription: vector<u8> = b"A worldview card which can get some rewards from Mirror Realms in the future";
    const CollectionUri: vector<u8> = b"https://ipfs.io/ipfs/QmRJz9e4ka4vEhSLn8h6uzfvcxMwi6KVEXuKBNpWHDQHfL";

    const TokenNamePrefix: vector<u8> = b"WVCard";
    const TokenDescription: vector<u8> = b"A worldview card which can get some rewards from Mirror Realms in the future";

    const TokenPropsKey: vector<vector<u8>> = vector[
        b"Character",
        b"Rank",
        b"Chess",
        b"Material"
    ];

    const TokenPropsType: vector<vector<u8>> = vector[
        b"0x1::string::String",
        b"0x1::string::String",
        b"0x1::string::String",
        b"0x1::string::String",
    ];

    const WhiteListStartTimestamp: u64 = 0;
    const PublicListStartTimestamp: u64 = 0;
    const WhiteListMaxCount: u64 = 350;
    const PublicListMaxCount: u64 = 1218;

    struct AdminList has key {
        list: acl::ACL
    }

    struct NFTInfo has store, drop, copy{
        uri: string::String,
        props: Benefit,
    }

    struct SelledNftInfo has store, drop, copy{
        owner: address,
        tokenId: address,
        name: string::String,
        uri: string::String,
        description: string::String,
        props: Benefit,
        collectionName: string::String,
        collectionDescription: string::String,
        collectionUri: string::String,
        collectionCreator: address,
    }

    struct SellConfig has store {

        whiteListAddress: vec_set::VecSet<address>,
        whiteListSelledAddress: smart_vector::SmartVector<address>,
        whiteListSelledNFTInfo: smart_vector::SmartVector<SelledNftInfo>,
        // White List start time
        whiteListStartTimestamp: u64,
        // Not Mint NFT Info Pool
        whiteListNftPool: smart_vector::SmartVector<NFTInfo>,
        whiteListNftPoolMaxCount: u64,


        // Public address List can mint
        publicListAddress: smart_vector::SmartVector<address>,
        // Public minted address
        publicListSelledAddress: smart_vector::SmartVector<address>,
        // Public minted NFT Info
        publicListSelledNFTInfo: smart_vector::SmartVector<SelledNftInfo>,
        publicListStartTimestamp: u64,
        // Not Mint NFT Info Pool
        publicListNftPool: smart_vector::SmartVector<NFTInfo>,
        // Public List NFT Pool Max Count
        publicListNftPoolMaxCount: u64,

        // All Selled NFT Info
        SelledNFTInfo: smart_table::SmartTable<Benefit, string::String>,
    }

    struct TokenRef has key {
        mutatorRef: token::MutatorRef,
        propertyMutatorRef: property_map::MutatorRef,
        burnRef: token::BurnRef,
        extendRef: object::ExtendRef,
        transferRef: object::TransferRef
    }

    struct Benefit has key, store, drop, copy{
        character: string::String,
        rank: string::String,
        chess: string::String,
        material: string::String,
    }

    struct MintEvent has store, drop, copy {
        minter: address,
        whiteList: bool,
        name: string::String,
        uri: string::String,
        description: string::String,
        collectionName: string::String,
        props: Benefit,
        timestamp: u64,
    }

    struct Collection has store {
        addr: address,
        mutatorRef: collection::MutatorRef
    }

    struct State has key {
        cap: SignerCapability,
        sellConfig: SellConfig,
        collection: Collection,
        mint_event_handler: event::EventHandle<MintEvent>,
    }

    fun init_module(sender: &signer) {
        let (signer, cap) = account::create_resource_account(sender, SEED);
        let collectionConstructorRef = collection::create_fixed_collection(
            &signer,
            string::utf8(CollectionDescription),
            MaxCount,
            string::utf8(CollectionName),
            option::some(royalty::create(80, 1000, @MR)),
            string::utf8(CollectionUri),
        );

        let acl = acl::empty();
        acl::add(&mut acl, signer::address_of(sender));
        move_to(&signer, AdminList{
            list:acl
        });

        move_to(&signer, State {
            cap,
            sellConfig: SellConfig {

                whiteListAddress: vec_set::empty(),
                whiteListSelledAddress: smart_vector::empty(),
                whiteListSelledNFTInfo: smart_vector::empty(),
                whiteListStartTimestamp: WhiteListStartTimestamp,
                whiteListNftPool: smart_vector::empty(),
                whiteListNftPoolMaxCount: WhiteListMaxCount,

                publicListAddress: smart_vector::empty(),
                publicListSelledAddress:smart_vector::empty(),
                publicListSelledNFTInfo: smart_vector::empty(),
                publicListStartTimestamp: PublicListStartTimestamp,
                publicListNftPool: smart_vector::empty(),
                publicListNftPoolMaxCount: PublicListMaxCount,


                SelledNFTInfo: smart_table::new(),
            },
            collection: Collection {
                addr: object::address_from_constructor_ref(&collectionConstructorRef),
                mutatorRef: collection::generate_mutator_ref(&collectionConstructorRef),
            },
            mint_event_handler: account::new_event_handle(&signer),
        })
    }

    fun get_resource_address(): address {
        account::create_resource_address(&@MR, SEED)
    }
    fun get_resource_signer(state: &State): signer{
        account::create_signer_with_capability(&state.cap)
    }

    entry fun white_list_mint(sender: &signer) acquires State {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let resource_signer = & get_resource_signer(state);

        // Assert Mint
        assert_sell_start(state.sellConfig.whiteListStartTimestamp);
        assert_is_white_list_address(
            state,
            sender_address
        );

        // set Sell config

        vec_set::remove(&mut state.sellConfig.whiteListAddress, &sender_address);
        smart_vector::push_back(&mut state.sellConfig.whiteListSelledAddress, sender_address);

        assert!( smart_vector::length(&state.sellConfig.whiteListSelledNFTInfo) <= state.sellConfig.whiteListNftPoolMaxCount , EInsufficientNFTPool);
        let len = smart_vector::length(&state.sellConfig.whiteListNftPool);
        assert!(len > 0, EInsufficientWhiteNFTPool);

        let index = pseudo_random(sender_address, len);
        let nft_info = smart_vector::remove(&mut state.sellConfig.whiteListNftPool, index);

        let collection_object =  object::address_to_object<collection::Collection>(state.collection.addr);
        let  supply_count = option::destroy_some(collection::count(collection_object));

        let tokenName = string::utf8(TokenNamePrefix);
        string::append(&mut tokenName, string_utils::format1(&b" #{}", supply_count + 1));

        // Mint Token
        let token_ref = token::create_named_token(
            resource_signer,
            string::utf8(CollectionName),
            string::utf8(CollectionDescription),
            tokenName,
            option::some(royalty::create(80, 1000, @MR)),
            nft_info.uri
        );

        let token_signer = &object::generate_signer(&token_ref);
        let propertyMutatorRef = property_map::generate_mutator_ref(&token_ref);
        let token_property = property_map::prepare_input(
            vector::map(TokenPropsKey, |x| {
                let key = string::utf8(x);
                key
            }),
            vector::map(TokenPropsType, |x| {
                let type = string::utf8(x);
                type
            }),
            vector[
                bcs::to_bytes(&nft_info.props.character),
                bcs::to_bytes(&nft_info.props.rank),
                bcs::to_bytes(&nft_info.props.chess),
                bcs::to_bytes(&nft_info.props.material),
            ]
        );
        property_map::init(&token_ref, token_property);

        move_to(token_signer, TokenRef {
            mutatorRef: token::generate_mutator_ref(&token_ref),
            propertyMutatorRef,
            burnRef: token::generate_burn_ref(&token_ref),
            extendRef: object::generate_extend_ref(&token_ref),
            transferRef: object::generate_transfer_ref(&token_ref)
        });

        move_to(token_signer, Benefit{
            character: nft_info.props.character,
            rank: nft_info.props.rank,
            chess: nft_info.props.chess,
            material: nft_info.props.material,
        });

        let token_object = object::object_from_constructor_ref<Token>(&token_ref);
        // Transfer Token
        object::transfer(resource_signer, token_object, sender_address);

        smart_vector::push_back(&mut state.sellConfig.whiteListSelledNFTInfo, SelledNftInfo{
            owner: sender_address,
            tokenId: object::object_address(&token_object),
            name: token::name(token_object),
            uri:token::uri(token_object),
            description:token::description(token_object),
            props: nft_info.props,
            collectionName: collection::name(collection_object),
            collectionDescription: collection::description(collection_object),
            collectionUri: collection::uri(collection_object),
            collectionCreator: collection::creator(collection_object),
        });

        smart_table::add(&mut state.sellConfig.SelledNFTInfo, nft_info.props, token::name(token_object));

        event::emit_event(&mut state.mint_event_handler, MintEvent {
            minter: sender_address,
            whiteList: true,
            name: token::name(token_object),
            uri:token::uri(token_object),
            description: string::utf8(TokenDescription),
            collectionName: string::utf8(CollectionName),
            props: nft_info.props,
            timestamp: timestamp::now_seconds(),
        })
    }

    // admin
    entry fun mint (sender: &signer, count: u64) acquires State, AdminList {
        let sender_address = signer::address_of(sender);

        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);

        let resource_signer = & get_resource_signer(state);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        // Assert Mint
        assert_sell_start(state.sellConfig.publicListStartTimestamp);

        let len = smart_vector::length(&state.sellConfig.publicListAddress);

        assert!(len >= count, EInsufficientPublicNFTPool);

        let i = 0;
        while(i < count){
            let addr = smart_vector::remove(&mut state.sellConfig.publicListAddress, 0);

            let index= 0;
            if (smart_vector::length(&state.sellConfig.publicListNftPool) == 0){

            }else {
                index = pseudo_random(addr, smart_vector::length(&state.sellConfig.publicListNftPool))
            };
            let nft_info = smart_vector::remove(&mut state.sellConfig.publicListNftPool, index);
            let collection_object =  object::address_to_object<collection::Collection>(state.collection.addr);
            let supply_count = option::destroy_some(collection::count(collection_object));

            let tokenName = string::utf8(TokenNamePrefix);
            string::append(&mut tokenName, string_utils::format1(&b" #{}", supply_count + 1));

            // Mint Token
            let token_ref = token::create_named_token(
                resource_signer,
                string::utf8(CollectionName),
                string::utf8(CollectionDescription),
                tokenName,
                option::some(royalty::create(80, 1000, @MR)),
                nft_info.uri
            );

            let token_signer = &object::generate_signer(&token_ref);
            let propertyMutatorRef = property_map::generate_mutator_ref(&token_ref);
            let token_property = property_map::prepare_input(
                vector::map(TokenPropsKey, |x| {
                    let key = string::utf8(x);
                    key
                }),
                vector::map(TokenPropsType, |x| {
                    let type = string::utf8(x);
                    type
                }),
                vector[
                    bcs::to_bytes(&nft_info.props.character),
                    bcs::to_bytes(&nft_info.props.rank),
                    bcs::to_bytes(&nft_info.props.chess),
                    bcs::to_bytes(&nft_info.props.material),
                ]
            );
            property_map::init(&token_ref, token_property);

            move_to(token_signer, TokenRef {
                mutatorRef: token::generate_mutator_ref(&token_ref),
                propertyMutatorRef,
                burnRef: token::generate_burn_ref(&token_ref),
                extendRef: object::generate_extend_ref(&token_ref),
                transferRef: object::generate_transfer_ref(&token_ref)
            });

            move_to(token_signer, Benefit{
                character: nft_info.props.character,
                rank: nft_info.props.rank,
                chess: nft_info.props.chess,
                material: nft_info.props.material,
            });

            let token_object = object::object_from_constructor_ref<Token>(&token_ref);
            // Transfer Token
            object::transfer(resource_signer, token_object, addr);

            smart_vector::push_back(&mut state.sellConfig.publicListSelledNFTInfo, SelledNftInfo{
                owner: addr,
                tokenId: object::object_address(&token_object),
                name: token::name(token_object),
                uri:token::uri(token_object),
                description:token::description(token_object),
                props: nft_info.props,
                collectionName: collection::name(collection_object),
                collectionDescription: collection::description(collection_object),
                collectionUri: collection::uri(collection_object),
                collectionCreator: collection::creator(collection_object),
            });
            i = i + 1;
        }
    }

     fun assert_sell_start(time: u64) {
        assert!(time <= timestamp::now_seconds(), ESaleNotStarted);
    }

    fun assert_sell_not_start(time: u64){
        assert!(time > timestamp::now_seconds(), ESaleStarted)
    }

     fun assert_sell_count(count: u64, maxCount: u64) {
        assert!(count < maxCount, ESoldOut);
    }

     fun assert_is_white_list_address(state: &State, user: address) {
        assert!(vec_set::contains(&state.sellConfig.whiteListAddress, &user), ENotWhiteListAddress);
    }

    fun pseudo_random(add:address,remaining:u64):u64
    {
        let x = bcs::to_bytes<address>(&add);
        let y = bcs::to_bytes<u64>(&remaining);
        let z = bcs::to_bytes<u64>(&timestamp::now_seconds());
        vector::append(&mut x,y);
        vector::append(&mut x,z);
        let tmp = hash::sha3_256(x);

        let data = vector<u8>[];
        let i =24;
        while (i < 32)
            {
                let x =vector::borrow(&tmp,i);
                vector::append(&mut data,vector<u8>[*x]);
                i= i+1;
            };
        assert!(remaining>0,999);

        let random = from_bcs::to_u64(data) % remaining;
        random
    }

    // admin

    entry fun add_admin(sender: &signer, addr: address) acquires AdminList, State {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global<State>(resource_address);
        if(!exists<AdminList>(resource_address)){
            let acl = acl::empty();
            acl::add(&mut acl , @MR);
            move_to(&account::create_signer_with_capability(&state.cap), AdminList{
                list: acl
            })
        };
        let acl = borrow_global_mut<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        acl::add(&mut acl.list, addr)
    }

    entry fun remove_admin(sender: &signer, addr: address)acquires AdminList{
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let acl = borrow_global_mut<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        acl::remove(&mut acl.list, addr)
    }

    entry fun set_white_list_start_timestamp(sender: &signer, timestamp: u64) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        state.sellConfig.whiteListStartTimestamp = timestamp;
    }

    entry fun set_white_list_address( sender: &signer, white_list_address: vector<address>, isClean : bool) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        if(isClean){
            state.sellConfig.whiteListAddress = vec_set::empty();
        };
        assert!( vec_set::size(&state.sellConfig.whiteListAddress) + smart_vector::length(&state.sellConfig.whiteListSelledAddress) + vector::length(&white_list_address) <= WhiteListMaxCount,  ETooManyWhiteListAddress );

        vector::for_each(white_list_address,| addr | {
            let addr:address = addr;
            assert!(!smart_vector::contains(&state.sellConfig.whiteListSelledAddress, &addr), EWhiteListAddress);
            vec_set::insert(&mut state.sellConfig.whiteListAddress, addr);
        })
    }

    entry fun add_white_list_address(sender: &signer, white_list_address:  address) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        assert!( vec_set::size(&state.sellConfig.whiteListAddress) + smart_vector::length(&state.sellConfig.whiteListSelledAddress) + 1 <= WhiteListMaxCount,  ETooManyWhiteListAddress );
        assert!(!smart_vector::contains(&state.sellConfig.whiteListSelledAddress, &white_list_address), EWhiteListAddress);
        vec_set::insert(&mut state.sellConfig.whiteListAddress, white_list_address);
    }

    entry fun remove_white_list_address(sender: &signer,  white_list_address:  address) acquires State, AdminList{
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        vec_set::remove(&mut state.sellConfig.whiteListAddress, &white_list_address);
    }

    entry fun set_white_list_nft_pool(
        sender: &signer,
        urls:vector<string::String>,
        character: vector<string::String>,
        rank: vector<string::String>,
        chess: vector<string::String>,
        material:vector<string::String>,
        isClean : bool
    ) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        assert! ( vector::length(&urls) == vector::length(&character)
                && vector::length(&urls) == vector::length(&rank)
                && vector::length(&urls) == vector::length(&chess)
                && vector::length(&urls) == vector::length(&material)
            , 0);
        assert_sell_not_start(state.sellConfig.whiteListStartTimestamp);
        let nft_pool = vector[];
        let i = 0;
        let len = vector::length(&urls);
        while (i < len)
            {
                let nft = NFTInfo{
                    uri: *vector::borrow(&urls, i),
                    props: Benefit{
                        character: *vector::borrow(&character, i),
                        rank: *vector::borrow(&rank, i),
                        chess: *vector::borrow(&chess, i),
                        material: *vector::borrow(&material, i),
                    }
                };
                vector::push_back(&mut nft_pool, nft);
                i = i+1;
            };
        assert!(vector::length(&nft_pool) + smart_vector::length(& state.sellConfig.whiteListNftPool) <= WhiteListMaxCount ,EWhiteListCountTooMany);
        vector::for_each(nft_pool,| nft | {
            let nft:NFTInfo = nft;
            smart_vector::push_back(&mut state.sellConfig.whiteListNftPool, nft);
        })
    }

    entry fun set_public_list_start_timestamp(sender: &signer, timestamp: u64) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        state.sellConfig.publicListStartTimestamp = timestamp;
    }

    entry fun set_public_list_address(sender: &signer,public_list_address: vector<address>, isClean : bool) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        if(isClean){
            let len = smart_vector::length(&state.sellConfig.publicListAddress);
            let i = 0;
            while (i < len)
                {
                    smart_vector::remove(&mut state.sellConfig.publicListAddress, 0);
                    i = i+1;
                };
        };
        assert!( smart_vector::length(&state.sellConfig.publicListAddress) + smart_vector::length(&state.sellConfig.publicListSelledAddress) + vector::length(&public_list_address) <= PublicListMaxCount,  ETooManyPublicListAddress );
        vector::for_each(public_list_address,| addr | {
            let addr:address = addr;
            smart_vector::push_back(&mut state.sellConfig.publicListAddress, addr);
        })
    }

    entry fun set_public_nft_pool(
        sender: &signer,
        urls:vector<string::String>,
        character: vector<string::String>,
        rank: vector<string::String>,
        chess: vector<string::String>,
        material:vector<string::String>,
        isClean : bool
    ) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        assert_sell_not_start(state.sellConfig.publicListStartTimestamp);
        assert! ( vector::length(&urls) == vector::length(&character)
                && vector::length(&urls) == vector::length(&rank)
                && vector::length(&urls) == vector::length(&chess)
                && vector::length(&urls) == vector::length(&material)
            , 0);
        let nft_pool = vector[];
        let i = 0;
        let len = vector::length(&urls);
        while (i < len)
            {
                let nft = NFTInfo{
                    uri: *vector::borrow(&urls, i),
                    props: Benefit{
                        character: *vector::borrow(&character, i),
                        rank: *vector::borrow(&rank, i),
                        chess: *vector::borrow(&chess, i),
                        material: *vector::borrow(&material, i),
                    }
                };
                vector::push_back(&mut nft_pool, nft);
                i = i+1;
        };
        assert!(vector::length(&nft_pool) + smart_vector::length(& state.sellConfig.publicListNftPool) <= PublicListMaxCount - 2 ,EPublicListCountTooMany);

        vector::for_each(nft_pool,| nft | {
            let nft:NFTInfo = nft;
            smart_vector::push_back(&mut state.sellConfig.publicListNftPool, nft);
        })
    }

    entry fun clean_public_nft_pool(sender: &signer, count: u64) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        assert_sell_not_start(state.sellConfig.publicListStartTimestamp);
        let len = smart_vector::length(&state.sellConfig.publicListNftPool);
        assert!(count <= len, 1);
        let i = 0;
        while (i < count)
            {
                smart_vector::pop_back(&mut state.sellConfig.publicListNftPool);
                i = i+1;
            };
    }

    entry fun clean_white_nft_pool(sender: &signer, count: u64) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        assert_sell_not_start(state.sellConfig.whiteListStartTimestamp);
        let len = smart_vector::length(&state.sellConfig.whiteListNftPool);
        assert!(count <= len, 1);
        let i = 0;
        while (i < count)
            {
                smart_vector::pop_back(&mut state.sellConfig.whiteListNftPool);
                i = i+1;
            };
    }

    entry fun set_public_berth_nft_pool(
        sender: &signer,
        urls:vector<string::String>,
        character: vector<string::String>,
        rank: vector<string::String>,
        chess: vector<string::String>,
        material:vector<string::String>
    ) acquires State, AdminList {
        let sender_address = signer::address_of(sender);
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let acl = borrow_global<AdminList>(resource_address);
        acl::assert_contains(&acl.list, sender_address);
        assert! ( vector::length(&urls) == vector::length(&character)
                && vector::length(&urls) == vector::length(&rank)
                && vector::length(&urls) == vector::length(&chess)
                && vector::length(&urls) == vector::length(&material)
                && vector::length(&urls) == 2
            , 0);
        let nft_pool = vector[];
        let i = 0;
        let len = vector::length(&urls);
        while (i < len)
            {
                let nft = NFTInfo{
                    uri: *vector::borrow(&urls, i),
                    props: Benefit{
                        character: *vector::borrow(&character, i),
                        rank: *vector::borrow(&rank, i),
                        chess: *vector::borrow(&chess, i),
                        material: *vector::borrow(&material, i),
                    }
                };
                vector::push_back(&mut nft_pool, nft);
                i = i+1;
            };
        vector::for_each(nft_pool,| nft | {
            let nft:NFTInfo = nft;
            smart_vector::push_back(&mut state.sellConfig.publicListNftPool, nft);
        })
    }


    #[view]
    fun get_white_list_address(): vector<address> acquires State {
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        vec_set::into_keys(state.sellConfig.whiteListAddress)
    }

    #[view]
    fun get_public_list_address(): vector<address> acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let vec = vector[];
        let len = smart_vector::length(&state.sellConfig.publicListAddress);
        let i = 0;
        while (i < len)
            {
                let x = smart_vector::borrow(&state.sellConfig.publicListAddress,i);
                vector::push_back(&mut vec, *x);
                i = i+1;
            };
        vec
    }

    #[view]
    fun get_white_list_selled_address(): vector<address> acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let vec = vector[];
        let len = smart_vector::length(&state.sellConfig.whiteListSelledAddress);
        let i = 0;
        while (i < len)
            {
                let x = smart_vector::borrow(&state.sellConfig.whiteListSelledAddress,i);
                vector::push_back(&mut vec, *x);
                i = i+1;
            };
        vec
    }

    #[view]
    fun get_public_list_selled_address(): vector<address> acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let vec = vector[];
        let len = smart_vector::length(&state.sellConfig.publicListSelledAddress);
        let i = 0;
        while (i < len)
            {
                let x = smart_vector::borrow(&state.sellConfig.publicListSelledAddress,i);
                vector::push_back(&mut vec, *x);
                i = i+1;
            };
        vec
    }

    #[view]
    fun get_white_list_mint_nft_count(): u64 acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        smart_vector::length(&state.sellConfig.whiteListSelledNFTInfo)
    }

    #[view]
    fun get_public_list_mint_nft_count(): u64 acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        smart_vector::length(&state.sellConfig.publicListSelledNFTInfo)
    }

    #[view]
    fun get_white_list_minted_nfts():vector<SelledNftInfo> acquires State {
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let vec = vector[];
        let len = smart_vector::length(&state.sellConfig.whiteListSelledNFTInfo);
        let i = 0;
        while (i < len)
            {
                let x = smart_vector::borrow(&state.sellConfig.whiteListSelledNFTInfo,i);
                vector::push_back(&mut vec, *x);
                i = i+1;
            };
        vector::for_each_mut(&mut vec, |item| {
            let item: &mut SelledNftInfo = item;
            let token_object = object::address_to_object<Token>(item.tokenId);
            item.owner = object::owner(token_object);
        });
        vec
    }

    #[view]
    fun get_public_list_minted_nfts():vector<SelledNftInfo> acquires State {
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let vec = vector[];
        let len = smart_vector::length(&state.sellConfig.publicListSelledNFTInfo);
        let i = 0;
        while (i < len)
            {
                let x = smart_vector::borrow(&state.sellConfig.publicListSelledNFTInfo,i);
                vector::push_back(&mut vec, *x);
                i = i+1;
            };
        vector::for_each_mut(&mut vec, |item| {
            let item: &mut SelledNftInfo = item;
            let token_object = object::address_to_object<Token>(item.tokenId);
            item.owner = object::owner(token_object);
        });
        vec
    }

    #[view]
    fun is_white_list_address(address: address): bool acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        vec_set::contains(&state.sellConfig.whiteListAddress, &address)
    }

    #[view]
    fun is_white_list_minted(id: u64): bool acquires State{
        let tokenName = string::utf8(TokenNamePrefix);
        string::append(&mut tokenName, string_utils::format1(&b" #{}", id));
        let resource_address = get_resource_address();
        let state = borrow_global<State>(resource_address);
        let len = smart_vector::length(&state.sellConfig.whiteListSelledNFTInfo);
        let i = 0;
        while (i < len)
        {
            let x = smart_vector::borrow(&state.sellConfig.whiteListSelledNFTInfo,i);
            if(x.name == tokenName){
                return true
            };
            i = i+1;
        };
        false
    }

    #[view]
    fun get_nft_by_id(
        id: u64
    ): SelledNftInfo acquires State, Benefit {
        let resource_address = get_resource_address();
        let state = borrow_global<State>(resource_address);
        let tokenName = string::utf8(TokenNamePrefix);
        string::append(&mut tokenName, string_utils::format1(&b" #{}", id));
        let token = token::create_token_address(
            &resource_address,
            &string::utf8(CollectionName),
            &tokenName
        );
        let token_object = object::address_to_object<Token>(token);
        let collection_object =  object::address_to_object<collection::Collection>(state.collection.addr);

        let benefit = borrow_global<Benefit>(object::object_address(&token_object));
        SelledNftInfo{
            owner: object::owner(token_object),
            tokenId: object::object_address(&token_object),
            name: token::name(token_object),
            uri:token::uri(token_object),
            description:token::description(token_object),
            props: *benefit,
            collectionName: collection::name(collection_object),
            collectionDescription: collection::description(collection_object),
            collectionUri: collection::uri(collection_object),
            collectionCreator: collection::creator(collection_object),
        }
    }

    #[view]
    fun get_nft_by_props(
        character: string::String,
        rank: string::String,
        chess: string::String,
        material: string::String
    ): SelledNftInfo acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let benefit = Benefit{
            character,
            rank,
            chess,
            material,
        };
        assert!( smart_table::contains(&state.sellConfig.SelledNFTInfo, benefit) , 1);
        let name = smart_table::borrow(&state.sellConfig.SelledNFTInfo, benefit);
        let token = token::create_token_address(
            &resource_address,
            &string::utf8(CollectionName),
            name
        );
        let token_object = object::address_to_object<Token>(token);
        let collection_object =  object::address_to_object<collection::Collection>(state.collection.addr);
        SelledNftInfo{
            owner: object::owner(token_object),
            tokenId: object::object_address(&token_object),
            name: token::name(token_object),
            uri:token::uri(token_object),
            description:token::description(token_object),
            props: benefit,
            collectionName: collection::name(collection_object),
            collectionDescription: collection::description(collection_object),
            collectionUri: collection::uri(collection_object),
            collectionCreator: collection::creator(collection_object),
        }
    }

    #[view]
    fun get_white_list_start_timestamp(): u64 acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        state.sellConfig.whiteListStartTimestamp
    }

    #[view]
    fun get_public_list_start_timestamp(): u64 acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        state.sellConfig.publicListStartTimestamp
    }

    #[view]
    fun get_public_list_nft_pool(): vector<NFTInfo> acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let vec = vector[];
        let len = smart_vector::length(&state.sellConfig.publicListNftPool);
        let i = 0;
        while (i < len)
            {
                let x = smart_vector::borrow(&state.sellConfig.publicListNftPool,i);
                vector::push_back(&mut vec, *x);
                i = i+1;
            };
        vec
    }

    #[view]
    fun get_public_list_nft_pool_count():u64 acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        smart_vector::length(&state.sellConfig.publicListNftPool)
    }

    #[view]
    fun get_white_list_nft_pool(): vector<NFTInfo> acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        let vec = vector[];
        let len = smart_vector::length(&state.sellConfig.whiteListNftPool);
        let i = 0;
        while (i < len)
            {
                let x = smart_vector::borrow(&state.sellConfig.whiteListNftPool,i);
                vector::push_back(&mut vec, *x);
                i = i+1;
            };
        vec
    }

    #[view]
    fun get_white_list_nft_pool_count():u64 acquires State{
        let resource_address = get_resource_address();
        let state = borrow_global_mut<State>(resource_address);
        smart_vector::length(&state.sellConfig.whiteListNftPool)
    }
}