export type FuncNameType = typeof _functions;
export type FuncNameKeys = keyof FuncNameType;

export const contractAddress = import.meta.env.VITE_CONTRACT_ADDRESS;

export const _functions = {
  mint: `${contractAddress}::weapon::mint`,
  get_weapon_by_object: `${contractAddress}::weapon::get_weapon_by_object`,
  craft: `${contractAddress}::weapon::craft`,
  white_list_mint: `${contractAddress}::nft::white_list_mint`,
  get_nft_by_id: `${contractAddress}::nft::get_nft_by_id`,
  get_white_list_nft_pool_count: `${contractAddress}::nft::get_white_list_nft_pool_count`,
};
