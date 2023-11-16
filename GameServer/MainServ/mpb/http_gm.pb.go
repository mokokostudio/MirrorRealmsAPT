// Code generated by protoc-gen-go. DO NOT EDIT.
// versions:
// 	protoc-gen-go v1.26.0
// 	protoc        v4.24.3
// source: http_gm.proto

package mpb

import (
	protoreflect "google.golang.org/protobuf/reflect/protoreflect"
	protoimpl "google.golang.org/protobuf/runtime/protoimpl"
	reflect "reflect"
	sync "sync"
)

const (
	// Verify that this generated code is sufficiently up-to-date.
	_ = protoimpl.EnforceVersion(20 - protoimpl.MinVersion)
	// Verify that runtime/protoimpl is sufficiently up-to-date.
	_ = protoimpl.EnforceVersion(protoimpl.MaxVersion - 20)
)

type CReqAdminLoginByPassword struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Account  string `protobuf:"bytes,1,opt,name=account,proto3" json:"account,omitempty"`
	Password string `protobuf:"bytes,2,opt,name=password,proto3" json:"password,omitempty"`
}

func (x *CReqAdminLoginByPassword) Reset() {
	*x = CReqAdminLoginByPassword{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[0]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CReqAdminLoginByPassword) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CReqAdminLoginByPassword) ProtoMessage() {}

func (x *CReqAdminLoginByPassword) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[0]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CReqAdminLoginByPassword.ProtoReflect.Descriptor instead.
func (*CReqAdminLoginByPassword) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{0}
}

func (x *CReqAdminLoginByPassword) GetAccount() string {
	if x != nil {
		return x.Account
	}
	return ""
}

func (x *CReqAdminLoginByPassword) GetPassword() string {
	if x != nil {
		return x.Password
	}
	return ""
}

type CResAdminLoginByPassword struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Token string `protobuf:"bytes,1,opt,name=token,proto3" json:"token,omitempty"`
}

func (x *CResAdminLoginByPassword) Reset() {
	*x = CResAdminLoginByPassword{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[1]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CResAdminLoginByPassword) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CResAdminLoginByPassword) ProtoMessage() {}

func (x *CResAdminLoginByPassword) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[1]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CResAdminLoginByPassword.ProtoReflect.Descriptor instead.
func (*CResAdminLoginByPassword) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{1}
}

func (x *CResAdminLoginByPassword) GetToken() string {
	if x != nil {
		return x.Token
	}
	return ""
}

type CReqAdminGetAptosNFTOwner struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	TokenId string `protobuf:"bytes,1,opt,name=token_id,json=tokenId,proto3" json:"token_id,omitempty"`
}

func (x *CReqAdminGetAptosNFTOwner) Reset() {
	*x = CReqAdminGetAptosNFTOwner{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[2]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CReqAdminGetAptosNFTOwner) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CReqAdminGetAptosNFTOwner) ProtoMessage() {}

func (x *CReqAdminGetAptosNFTOwner) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[2]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CReqAdminGetAptosNFTOwner.ProtoReflect.Descriptor instead.
func (*CReqAdminGetAptosNFTOwner) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{2}
}

func (x *CReqAdminGetAptosNFTOwner) GetTokenId() string {
	if x != nil {
		return x.TokenId
	}
	return ""
}

type CResAdminGetAptosNFTOwner struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Owner *AccountInfo `protobuf:"bytes,1,opt,name=owner,proto3" json:"owner,omitempty"`
}

func (x *CResAdminGetAptosNFTOwner) Reset() {
	*x = CResAdminGetAptosNFTOwner{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[3]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CResAdminGetAptosNFTOwner) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CResAdminGetAptosNFTOwner) ProtoMessage() {}

func (x *CResAdminGetAptosNFTOwner) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[3]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CResAdminGetAptosNFTOwner.ProtoReflect.Descriptor instead.
func (*CResAdminGetAptosNFTOwner) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{3}
}

func (x *CResAdminGetAptosNFTOwner) GetOwner() *AccountInfo {
	if x != nil {
		return x.Owner
	}
	return nil
}

type CReqAdminGetAptosNFTsInCollection struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	CollectionId string `protobuf:"bytes,1,opt,name=collection_id,json=collectionId,proto3" json:"collection_id,omitempty"`
}

func (x *CReqAdminGetAptosNFTsInCollection) Reset() {
	*x = CReqAdminGetAptosNFTsInCollection{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[4]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CReqAdminGetAptosNFTsInCollection) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CReqAdminGetAptosNFTsInCollection) ProtoMessage() {}

func (x *CReqAdminGetAptosNFTsInCollection) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[4]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CReqAdminGetAptosNFTsInCollection.ProtoReflect.Descriptor instead.
func (*CReqAdminGetAptosNFTsInCollection) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{4}
}

func (x *CReqAdminGetAptosNFTsInCollection) GetCollectionId() string {
	if x != nil {
		return x.CollectionId
	}
	return ""
}

type CResAdminGetAptosNFTsInCollection struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	NftList []*AdminGetAptosNFTsInCollectionNode `protobuf:"bytes,1,rep,name=nft_list,json=nftList,proto3" json:"nft_list,omitempty"`
}

func (x *CResAdminGetAptosNFTsInCollection) Reset() {
	*x = CResAdminGetAptosNFTsInCollection{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[5]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CResAdminGetAptosNFTsInCollection) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CResAdminGetAptosNFTsInCollection) ProtoMessage() {}

func (x *CResAdminGetAptosNFTsInCollection) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[5]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CResAdminGetAptosNFTsInCollection.ProtoReflect.Descriptor instead.
func (*CResAdminGetAptosNFTsInCollection) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{5}
}

func (x *CResAdminGetAptosNFTsInCollection) GetNftList() []*AdminGetAptosNFTsInCollectionNode {
	if x != nil {
		return x.NftList
	}
	return nil
}

type CReqAdminGetCollectionNFTBuyers struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	CollectionId string `protobuf:"bytes,1,opt,name=collection_id,json=collectionId,proto3" json:"collection_id,omitempty"`
}

func (x *CReqAdminGetCollectionNFTBuyers) Reset() {
	*x = CReqAdminGetCollectionNFTBuyers{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[6]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CReqAdminGetCollectionNFTBuyers) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CReqAdminGetCollectionNFTBuyers) ProtoMessage() {}

func (x *CReqAdminGetCollectionNFTBuyers) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[6]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CReqAdminGetCollectionNFTBuyers.ProtoReflect.Descriptor instead.
func (*CReqAdminGetCollectionNFTBuyers) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{6}
}

func (x *CReqAdminGetCollectionNFTBuyers) GetCollectionId() string {
	if x != nil {
		return x.CollectionId
	}
	return ""
}

type CResAdminGetCollectionNFTBuyers struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	NftList []*AdminGetCollectionNFTBuyersNode `protobuf:"bytes,1,rep,name=nft_list,json=nftList,proto3" json:"nft_list,omitempty"`
}

func (x *CResAdminGetCollectionNFTBuyers) Reset() {
	*x = CResAdminGetCollectionNFTBuyers{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[7]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CResAdminGetCollectionNFTBuyers) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CResAdminGetCollectionNFTBuyers) ProtoMessage() {}

func (x *CResAdminGetCollectionNFTBuyers) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[7]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CResAdminGetCollectionNFTBuyers.ProtoReflect.Descriptor instead.
func (*CResAdminGetCollectionNFTBuyers) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{7}
}

func (x *CResAdminGetCollectionNFTBuyers) GetNftList() []*AdminGetCollectionNFTBuyersNode {
	if x != nil {
		return x.NftList
	}
	return nil
}

type CReqAdminGetCollectionNFTOffers struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	CollectionId string `protobuf:"bytes,1,opt,name=collection_id,json=collectionId,proto3" json:"collection_id,omitempty"`
	DstAddr      string `protobuf:"bytes,2,opt,name=dst_addr,json=dstAddr,proto3" json:"dst_addr,omitempty"`
	StartTime    string `protobuf:"bytes,3,opt,name=start_time,json=startTime,proto3" json:"start_time,omitempty"`
	EndTime      string `protobuf:"bytes,4,opt,name=end_time,json=endTime,proto3" json:"end_time,omitempty"`
}

func (x *CReqAdminGetCollectionNFTOffers) Reset() {
	*x = CReqAdminGetCollectionNFTOffers{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[8]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CReqAdminGetCollectionNFTOffers) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CReqAdminGetCollectionNFTOffers) ProtoMessage() {}

func (x *CReqAdminGetCollectionNFTOffers) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[8]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CReqAdminGetCollectionNFTOffers.ProtoReflect.Descriptor instead.
func (*CReqAdminGetCollectionNFTOffers) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{8}
}

func (x *CReqAdminGetCollectionNFTOffers) GetCollectionId() string {
	if x != nil {
		return x.CollectionId
	}
	return ""
}

func (x *CReqAdminGetCollectionNFTOffers) GetDstAddr() string {
	if x != nil {
		return x.DstAddr
	}
	return ""
}

func (x *CReqAdminGetCollectionNFTOffers) GetStartTime() string {
	if x != nil {
		return x.StartTime
	}
	return ""
}

func (x *CReqAdminGetCollectionNFTOffers) GetEndTime() string {
	if x != nil {
		return x.EndTime
	}
	return ""
}

type CResAdminGetCollectionNFTOffers struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	NftList []*AdminGetCollectionNFTOffersNode `protobuf:"bytes,1,rep,name=nft_list,json=nftList,proto3" json:"nft_list,omitempty"`
}

func (x *CResAdminGetCollectionNFTOffers) Reset() {
	*x = CResAdminGetCollectionNFTOffers{}
	if protoimpl.UnsafeEnabled {
		mi := &file_http_gm_proto_msgTypes[9]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *CResAdminGetCollectionNFTOffers) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*CResAdminGetCollectionNFTOffers) ProtoMessage() {}

func (x *CResAdminGetCollectionNFTOffers) ProtoReflect() protoreflect.Message {
	mi := &file_http_gm_proto_msgTypes[9]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use CResAdminGetCollectionNFTOffers.ProtoReflect.Descriptor instead.
func (*CResAdminGetCollectionNFTOffers) Descriptor() ([]byte, []int) {
	return file_http_gm_proto_rawDescGZIP(), []int{9}
}

func (x *CResAdminGetCollectionNFTOffers) GetNftList() []*AdminGetCollectionNFTOffersNode {
	if x != nil {
		return x.NftList
	}
	return nil
}

var File_http_gm_proto protoreflect.FileDescriptor

var file_http_gm_proto_rawDesc = []byte{
	0x0a, 0x0d, 0x68, 0x74, 0x74, 0x70, 0x5f, 0x67, 0x6d, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x12,
	0x03, 0x6d, 0x70, 0x62, 0x1a, 0x0c, 0x63, 0x6f, 0x6d, 0x6d, 0x6f, 0x6e, 0x2e, 0x70, 0x72, 0x6f,
	0x74, 0x6f, 0x1a, 0x0e, 0x67, 0x72, 0x70, 0x63, 0x5f, 0x6e, 0x66, 0x74, 0x2e, 0x70, 0x72, 0x6f,
	0x74, 0x6f, 0x22, 0x50, 0x0a, 0x18, 0x43, 0x52, 0x65, 0x71, 0x41, 0x64, 0x6d, 0x69, 0x6e, 0x4c,
	0x6f, 0x67, 0x69, 0x6e, 0x42, 0x79, 0x50, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x12, 0x18,
	0x0a, 0x07, 0x61, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52,
	0x07, 0x61, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x12, 0x1a, 0x0a, 0x08, 0x70, 0x61, 0x73, 0x73,
	0x77, 0x6f, 0x72, 0x64, 0x18, 0x02, 0x20, 0x01, 0x28, 0x09, 0x52, 0x08, 0x70, 0x61, 0x73, 0x73,
	0x77, 0x6f, 0x72, 0x64, 0x22, 0x30, 0x0a, 0x18, 0x43, 0x52, 0x65, 0x73, 0x41, 0x64, 0x6d, 0x69,
	0x6e, 0x4c, 0x6f, 0x67, 0x69, 0x6e, 0x42, 0x79, 0x50, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64,
	0x12, 0x14, 0x0a, 0x05, 0x74, 0x6f, 0x6b, 0x65, 0x6e, 0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52,
	0x05, 0x74, 0x6f, 0x6b, 0x65, 0x6e, 0x22, 0x36, 0x0a, 0x19, 0x43, 0x52, 0x65, 0x71, 0x41, 0x64,
	0x6d, 0x69, 0x6e, 0x47, 0x65, 0x74, 0x41, 0x70, 0x74, 0x6f, 0x73, 0x4e, 0x46, 0x54, 0x4f, 0x77,
	0x6e, 0x65, 0x72, 0x12, 0x19, 0x0a, 0x08, 0x74, 0x6f, 0x6b, 0x65, 0x6e, 0x5f, 0x69, 0x64, 0x18,
	0x01, 0x20, 0x01, 0x28, 0x09, 0x52, 0x07, 0x74, 0x6f, 0x6b, 0x65, 0x6e, 0x49, 0x64, 0x22, 0x43,
	0x0a, 0x19, 0x43, 0x52, 0x65, 0x73, 0x41, 0x64, 0x6d, 0x69, 0x6e, 0x47, 0x65, 0x74, 0x41, 0x70,
	0x74, 0x6f, 0x73, 0x4e, 0x46, 0x54, 0x4f, 0x77, 0x6e, 0x65, 0x72, 0x12, 0x26, 0x0a, 0x05, 0x6f,
	0x77, 0x6e, 0x65, 0x72, 0x18, 0x01, 0x20, 0x01, 0x28, 0x0b, 0x32, 0x10, 0x2e, 0x6d, 0x70, 0x62,
	0x2e, 0x41, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x49, 0x6e, 0x66, 0x6f, 0x52, 0x05, 0x6f, 0x77,
	0x6e, 0x65, 0x72, 0x22, 0x48, 0x0a, 0x21, 0x43, 0x52, 0x65, 0x71, 0x41, 0x64, 0x6d, 0x69, 0x6e,
	0x47, 0x65, 0x74, 0x41, 0x70, 0x74, 0x6f, 0x73, 0x4e, 0x46, 0x54, 0x73, 0x49, 0x6e, 0x43, 0x6f,
	0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x12, 0x23, 0x0a, 0x0d, 0x63, 0x6f, 0x6c, 0x6c,
	0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x5f, 0x69, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52,
	0x0c, 0x63, 0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x49, 0x64, 0x22, 0x66, 0x0a,
	0x21, 0x43, 0x52, 0x65, 0x73, 0x41, 0x64, 0x6d, 0x69, 0x6e, 0x47, 0x65, 0x74, 0x41, 0x70, 0x74,
	0x6f, 0x73, 0x4e, 0x46, 0x54, 0x73, 0x49, 0x6e, 0x43, 0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69,
	0x6f, 0x6e, 0x12, 0x41, 0x0a, 0x08, 0x6e, 0x66, 0x74, 0x5f, 0x6c, 0x69, 0x73, 0x74, 0x18, 0x01,
	0x20, 0x03, 0x28, 0x0b, 0x32, 0x26, 0x2e, 0x6d, 0x70, 0x62, 0x2e, 0x41, 0x64, 0x6d, 0x69, 0x6e,
	0x47, 0x65, 0x74, 0x41, 0x70, 0x74, 0x6f, 0x73, 0x4e, 0x46, 0x54, 0x73, 0x49, 0x6e, 0x43, 0x6f,
	0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x4e, 0x6f, 0x64, 0x65, 0x52, 0x07, 0x6e, 0x66,
	0x74, 0x4c, 0x69, 0x73, 0x74, 0x22, 0x46, 0x0a, 0x1f, 0x43, 0x52, 0x65, 0x71, 0x41, 0x64, 0x6d,
	0x69, 0x6e, 0x47, 0x65, 0x74, 0x43, 0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x4e,
	0x46, 0x54, 0x42, 0x75, 0x79, 0x65, 0x72, 0x73, 0x12, 0x23, 0x0a, 0x0d, 0x63, 0x6f, 0x6c, 0x6c,
	0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x5f, 0x69, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52,
	0x0c, 0x63, 0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x49, 0x64, 0x22, 0x62, 0x0a,
	0x1f, 0x43, 0x52, 0x65, 0x73, 0x41, 0x64, 0x6d, 0x69, 0x6e, 0x47, 0x65, 0x74, 0x43, 0x6f, 0x6c,
	0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x4e, 0x46, 0x54, 0x42, 0x75, 0x79, 0x65, 0x72, 0x73,
	0x12, 0x3f, 0x0a, 0x08, 0x6e, 0x66, 0x74, 0x5f, 0x6c, 0x69, 0x73, 0x74, 0x18, 0x01, 0x20, 0x03,
	0x28, 0x0b, 0x32, 0x24, 0x2e, 0x6d, 0x70, 0x62, 0x2e, 0x41, 0x64, 0x6d, 0x69, 0x6e, 0x47, 0x65,
	0x74, 0x43, 0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x4e, 0x46, 0x54, 0x42, 0x75,
	0x79, 0x65, 0x72, 0x73, 0x4e, 0x6f, 0x64, 0x65, 0x52, 0x07, 0x6e, 0x66, 0x74, 0x4c, 0x69, 0x73,
	0x74, 0x22, 0x9b, 0x01, 0x0a, 0x1f, 0x43, 0x52, 0x65, 0x71, 0x41, 0x64, 0x6d, 0x69, 0x6e, 0x47,
	0x65, 0x74, 0x43, 0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x4e, 0x46, 0x54, 0x4f,
	0x66, 0x66, 0x65, 0x72, 0x73, 0x12, 0x23, 0x0a, 0x0d, 0x63, 0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74,
	0x69, 0x6f, 0x6e, 0x5f, 0x69, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52, 0x0c, 0x63, 0x6f,
	0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x49, 0x64, 0x12, 0x19, 0x0a, 0x08, 0x64, 0x73,
	0x74, 0x5f, 0x61, 0x64, 0x64, 0x72, 0x18, 0x02, 0x20, 0x01, 0x28, 0x09, 0x52, 0x07, 0x64, 0x73,
	0x74, 0x41, 0x64, 0x64, 0x72, 0x12, 0x1d, 0x0a, 0x0a, 0x73, 0x74, 0x61, 0x72, 0x74, 0x5f, 0x74,
	0x69, 0x6d, 0x65, 0x18, 0x03, 0x20, 0x01, 0x28, 0x09, 0x52, 0x09, 0x73, 0x74, 0x61, 0x72, 0x74,
	0x54, 0x69, 0x6d, 0x65, 0x12, 0x19, 0x0a, 0x08, 0x65, 0x6e, 0x64, 0x5f, 0x74, 0x69, 0x6d, 0x65,
	0x18, 0x04, 0x20, 0x01, 0x28, 0x09, 0x52, 0x07, 0x65, 0x6e, 0x64, 0x54, 0x69, 0x6d, 0x65, 0x22,
	0x62, 0x0a, 0x1f, 0x43, 0x52, 0x65, 0x73, 0x41, 0x64, 0x6d, 0x69, 0x6e, 0x47, 0x65, 0x74, 0x43,
	0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x4e, 0x46, 0x54, 0x4f, 0x66, 0x66, 0x65,
	0x72, 0x73, 0x12, 0x3f, 0x0a, 0x08, 0x6e, 0x66, 0x74, 0x5f, 0x6c, 0x69, 0x73, 0x74, 0x18, 0x01,
	0x20, 0x03, 0x28, 0x0b, 0x32, 0x24, 0x2e, 0x6d, 0x70, 0x62, 0x2e, 0x41, 0x64, 0x6d, 0x69, 0x6e,
	0x47, 0x65, 0x74, 0x43, 0x6f, 0x6c, 0x6c, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x4e, 0x46, 0x54,
	0x4f, 0x66, 0x66, 0x65, 0x72, 0x73, 0x4e, 0x6f, 0x64, 0x65, 0x52, 0x07, 0x6e, 0x66, 0x74, 0x4c,
	0x69, 0x73, 0x74, 0x42, 0x07, 0x5a, 0x05, 0x2e, 0x2f, 0x6d, 0x70, 0x62, 0x62, 0x06, 0x70, 0x72,
	0x6f, 0x74, 0x6f, 0x33,
}

var (
	file_http_gm_proto_rawDescOnce sync.Once
	file_http_gm_proto_rawDescData = file_http_gm_proto_rawDesc
)

func file_http_gm_proto_rawDescGZIP() []byte {
	file_http_gm_proto_rawDescOnce.Do(func() {
		file_http_gm_proto_rawDescData = protoimpl.X.CompressGZIP(file_http_gm_proto_rawDescData)
	})
	return file_http_gm_proto_rawDescData
}

var file_http_gm_proto_msgTypes = make([]protoimpl.MessageInfo, 10)
var file_http_gm_proto_goTypes = []interface{}{
	(*CReqAdminLoginByPassword)(nil),          // 0: mpb.CReqAdminLoginByPassword
	(*CResAdminLoginByPassword)(nil),          // 1: mpb.CResAdminLoginByPassword
	(*CReqAdminGetAptosNFTOwner)(nil),         // 2: mpb.CReqAdminGetAptosNFTOwner
	(*CResAdminGetAptosNFTOwner)(nil),         // 3: mpb.CResAdminGetAptosNFTOwner
	(*CReqAdminGetAptosNFTsInCollection)(nil), // 4: mpb.CReqAdminGetAptosNFTsInCollection
	(*CResAdminGetAptosNFTsInCollection)(nil), // 5: mpb.CResAdminGetAptosNFTsInCollection
	(*CReqAdminGetCollectionNFTBuyers)(nil),   // 6: mpb.CReqAdminGetCollectionNFTBuyers
	(*CResAdminGetCollectionNFTBuyers)(nil),   // 7: mpb.CResAdminGetCollectionNFTBuyers
	(*CReqAdminGetCollectionNFTOffers)(nil),   // 8: mpb.CReqAdminGetCollectionNFTOffers
	(*CResAdminGetCollectionNFTOffers)(nil),   // 9: mpb.CResAdminGetCollectionNFTOffers
	(*AccountInfo)(nil),                       // 10: mpb.AccountInfo
	(*AdminGetAptosNFTsInCollectionNode)(nil), // 11: mpb.AdminGetAptosNFTsInCollectionNode
	(*AdminGetCollectionNFTBuyersNode)(nil),   // 12: mpb.AdminGetCollectionNFTBuyersNode
	(*AdminGetCollectionNFTOffersNode)(nil),   // 13: mpb.AdminGetCollectionNFTOffersNode
}
var file_http_gm_proto_depIdxs = []int32{
	10, // 0: mpb.CResAdminGetAptosNFTOwner.owner:type_name -> mpb.AccountInfo
	11, // 1: mpb.CResAdminGetAptosNFTsInCollection.nft_list:type_name -> mpb.AdminGetAptosNFTsInCollectionNode
	12, // 2: mpb.CResAdminGetCollectionNFTBuyers.nft_list:type_name -> mpb.AdminGetCollectionNFTBuyersNode
	13, // 3: mpb.CResAdminGetCollectionNFTOffers.nft_list:type_name -> mpb.AdminGetCollectionNFTOffersNode
	4,  // [4:4] is the sub-list for method output_type
	4,  // [4:4] is the sub-list for method input_type
	4,  // [4:4] is the sub-list for extension type_name
	4,  // [4:4] is the sub-list for extension extendee
	0,  // [0:4] is the sub-list for field type_name
}

func init() { file_http_gm_proto_init() }
func file_http_gm_proto_init() {
	if File_http_gm_proto != nil {
		return
	}
	file_common_proto_init()
	file_grpc_nft_proto_init()
	if !protoimpl.UnsafeEnabled {
		file_http_gm_proto_msgTypes[0].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CReqAdminLoginByPassword); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[1].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CResAdminLoginByPassword); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[2].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CReqAdminGetAptosNFTOwner); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[3].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CResAdminGetAptosNFTOwner); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[4].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CReqAdminGetAptosNFTsInCollection); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[5].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CResAdminGetAptosNFTsInCollection); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[6].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CReqAdminGetCollectionNFTBuyers); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[7].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CResAdminGetCollectionNFTBuyers); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[8].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CReqAdminGetCollectionNFTOffers); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_http_gm_proto_msgTypes[9].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*CResAdminGetCollectionNFTOffers); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
	}
	type x struct{}
	out := protoimpl.TypeBuilder{
		File: protoimpl.DescBuilder{
			GoPackagePath: reflect.TypeOf(x{}).PkgPath(),
			RawDescriptor: file_http_gm_proto_rawDesc,
			NumEnums:      0,
			NumMessages:   10,
			NumExtensions: 0,
			NumServices:   0,
		},
		GoTypes:           file_http_gm_proto_goTypes,
		DependencyIndexes: file_http_gm_proto_depIdxs,
		MessageInfos:      file_http_gm_proto_msgTypes,
	}.Build()
	File_http_gm_proto = out.File
	file_http_gm_proto_rawDesc = nil
	file_http_gm_proto_goTypes = nil
	file_http_gm_proto_depIdxs = nil
}
