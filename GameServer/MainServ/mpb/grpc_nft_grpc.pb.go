// Code generated by protoc-gen-go-grpc. DO NOT EDIT.
// versions:
// - protoc-gen-go-grpc v1.3.0
// - protoc             v4.24.3
// source: grpc_nft.proto

package mpb

import (
	context "context"
	grpc "google.golang.org/grpc"
	codes "google.golang.org/grpc/codes"
	status "google.golang.org/grpc/status"
)

// This is a compile-time assertion to ensure that this generated file
// is compatible with the grpc package it is being compiled against.
// Requires gRPC-Go v1.32.0 or later.
const _ = grpc.SupportPackageIsVersion7

const (
	NFTService_GetAptosNFTs_FullMethodName                  = "/mpb.NFTService/GetAptosNFTs"
	NFTService_GetAptosNFTMetadatas_FullMethodName          = "/mpb.NFTService/GetAptosNFTMetadatas"
	NFTService_GetAptosNFTsV2_FullMethodName                = "/mpb.NFTService/GetAptosNFTsV2"
	NFTService_GetAptosNFTOwner_FullMethodName              = "/mpb.NFTService/GetAptosNFTOwner"
	NFTService_AdminGetAptosNFTsInCollection_FullMethodName = "/mpb.NFTService/AdminGetAptosNFTsInCollection"
	NFTService_AdminGetCollectionNFTBuyers_FullMethodName   = "/mpb.NFTService/AdminGetCollectionNFTBuyers"
	NFTService_AdminGetCollectionNFTOffers_FullMethodName   = "/mpb.NFTService/AdminGetCollectionNFTOffers"
)

// NFTServiceClient is the client API for NFTService service.
//
// For semantics around ctx use and closing/ending streaming RPCs, please refer to https://pkg.go.dev/google.golang.org/grpc/?tab=doc#ClientConn.NewStream.
type NFTServiceClient interface {
	GetAptosNFTs(ctx context.Context, in *ReqGetAptosNFTs, opts ...grpc.CallOption) (*ResGetAptosNFTs, error)
	GetAptosNFTMetadatas(ctx context.Context, in *ReqGetAptosNFTMetadatas, opts ...grpc.CallOption) (*ResGetAptosNFTMetadatas, error)
	GetAptosNFTsV2(ctx context.Context, in *ReqGetAptosNFTsV2, opts ...grpc.CallOption) (*ResGetAptosNFTsV2, error)
	GetAptosNFTOwner(ctx context.Context, in *ReqGetAptosNFTOwner, opts ...grpc.CallOption) (*ResGetAptosNFTOwner, error)
	AdminGetAptosNFTsInCollection(ctx context.Context, in *ReqAdminGetAptosNFTsInCollection, opts ...grpc.CallOption) (*ResAdminGetAptosNFTsInCollection, error)
	AdminGetCollectionNFTBuyers(ctx context.Context, in *ReqAdminGetCollectionNFTBuyers, opts ...grpc.CallOption) (*ResAdminGetCollectionNFTBuyers, error)
	AdminGetCollectionNFTOffers(ctx context.Context, in *ReqAdminGetCollectionNFTOffers, opts ...grpc.CallOption) (*ResAdminGetCollectionNFTOffers, error)
}

type nFTServiceClient struct {
	cc grpc.ClientConnInterface
}

func NewNFTServiceClient(cc grpc.ClientConnInterface) NFTServiceClient {
	return &nFTServiceClient{cc}
}

func (c *nFTServiceClient) GetAptosNFTs(ctx context.Context, in *ReqGetAptosNFTs, opts ...grpc.CallOption) (*ResGetAptosNFTs, error) {
	out := new(ResGetAptosNFTs)
	err := c.cc.Invoke(ctx, NFTService_GetAptosNFTs_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *nFTServiceClient) GetAptosNFTMetadatas(ctx context.Context, in *ReqGetAptosNFTMetadatas, opts ...grpc.CallOption) (*ResGetAptosNFTMetadatas, error) {
	out := new(ResGetAptosNFTMetadatas)
	err := c.cc.Invoke(ctx, NFTService_GetAptosNFTMetadatas_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *nFTServiceClient) GetAptosNFTsV2(ctx context.Context, in *ReqGetAptosNFTsV2, opts ...grpc.CallOption) (*ResGetAptosNFTsV2, error) {
	out := new(ResGetAptosNFTsV2)
	err := c.cc.Invoke(ctx, NFTService_GetAptosNFTsV2_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *nFTServiceClient) GetAptosNFTOwner(ctx context.Context, in *ReqGetAptosNFTOwner, opts ...grpc.CallOption) (*ResGetAptosNFTOwner, error) {
	out := new(ResGetAptosNFTOwner)
	err := c.cc.Invoke(ctx, NFTService_GetAptosNFTOwner_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *nFTServiceClient) AdminGetAptosNFTsInCollection(ctx context.Context, in *ReqAdminGetAptosNFTsInCollection, opts ...grpc.CallOption) (*ResAdminGetAptosNFTsInCollection, error) {
	out := new(ResAdminGetAptosNFTsInCollection)
	err := c.cc.Invoke(ctx, NFTService_AdminGetAptosNFTsInCollection_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *nFTServiceClient) AdminGetCollectionNFTBuyers(ctx context.Context, in *ReqAdminGetCollectionNFTBuyers, opts ...grpc.CallOption) (*ResAdminGetCollectionNFTBuyers, error) {
	out := new(ResAdminGetCollectionNFTBuyers)
	err := c.cc.Invoke(ctx, NFTService_AdminGetCollectionNFTBuyers_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *nFTServiceClient) AdminGetCollectionNFTOffers(ctx context.Context, in *ReqAdminGetCollectionNFTOffers, opts ...grpc.CallOption) (*ResAdminGetCollectionNFTOffers, error) {
	out := new(ResAdminGetCollectionNFTOffers)
	err := c.cc.Invoke(ctx, NFTService_AdminGetCollectionNFTOffers_FullMethodName, in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

// NFTServiceServer is the server API for NFTService service.
// All implementations must embed UnimplementedNFTServiceServer
// for forward compatibility
type NFTServiceServer interface {
	GetAptosNFTs(context.Context, *ReqGetAptosNFTs) (*ResGetAptosNFTs, error)
	GetAptosNFTMetadatas(context.Context, *ReqGetAptosNFTMetadatas) (*ResGetAptosNFTMetadatas, error)
	GetAptosNFTsV2(context.Context, *ReqGetAptosNFTsV2) (*ResGetAptosNFTsV2, error)
	GetAptosNFTOwner(context.Context, *ReqGetAptosNFTOwner) (*ResGetAptosNFTOwner, error)
	AdminGetAptosNFTsInCollection(context.Context, *ReqAdminGetAptosNFTsInCollection) (*ResAdminGetAptosNFTsInCollection, error)
	AdminGetCollectionNFTBuyers(context.Context, *ReqAdminGetCollectionNFTBuyers) (*ResAdminGetCollectionNFTBuyers, error)
	AdminGetCollectionNFTOffers(context.Context, *ReqAdminGetCollectionNFTOffers) (*ResAdminGetCollectionNFTOffers, error)
	mustEmbedUnimplementedNFTServiceServer()
}

// UnimplementedNFTServiceServer must be embedded to have forward compatible implementations.
type UnimplementedNFTServiceServer struct {
}

func (UnimplementedNFTServiceServer) GetAptosNFTs(context.Context, *ReqGetAptosNFTs) (*ResGetAptosNFTs, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetAptosNFTs not implemented")
}
func (UnimplementedNFTServiceServer) GetAptosNFTMetadatas(context.Context, *ReqGetAptosNFTMetadatas) (*ResGetAptosNFTMetadatas, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetAptosNFTMetadatas not implemented")
}
func (UnimplementedNFTServiceServer) GetAptosNFTsV2(context.Context, *ReqGetAptosNFTsV2) (*ResGetAptosNFTsV2, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetAptosNFTsV2 not implemented")
}
func (UnimplementedNFTServiceServer) GetAptosNFTOwner(context.Context, *ReqGetAptosNFTOwner) (*ResGetAptosNFTOwner, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetAptosNFTOwner not implemented")
}
func (UnimplementedNFTServiceServer) AdminGetAptosNFTsInCollection(context.Context, *ReqAdminGetAptosNFTsInCollection) (*ResAdminGetAptosNFTsInCollection, error) {
	return nil, status.Errorf(codes.Unimplemented, "method AdminGetAptosNFTsInCollection not implemented")
}
func (UnimplementedNFTServiceServer) AdminGetCollectionNFTBuyers(context.Context, *ReqAdminGetCollectionNFTBuyers) (*ResAdminGetCollectionNFTBuyers, error) {
	return nil, status.Errorf(codes.Unimplemented, "method AdminGetCollectionNFTBuyers not implemented")
}
func (UnimplementedNFTServiceServer) AdminGetCollectionNFTOffers(context.Context, *ReqAdminGetCollectionNFTOffers) (*ResAdminGetCollectionNFTOffers, error) {
	return nil, status.Errorf(codes.Unimplemented, "method AdminGetCollectionNFTOffers not implemented")
}
func (UnimplementedNFTServiceServer) mustEmbedUnimplementedNFTServiceServer() {}

// UnsafeNFTServiceServer may be embedded to opt out of forward compatibility for this service.
// Use of this interface is not recommended, as added methods to NFTServiceServer will
// result in compilation errors.
type UnsafeNFTServiceServer interface {
	mustEmbedUnimplementedNFTServiceServer()
}

func RegisterNFTServiceServer(s grpc.ServiceRegistrar, srv NFTServiceServer) {
	s.RegisterService(&NFTService_ServiceDesc, srv)
}

func _NFTService_GetAptosNFTs_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(ReqGetAptosNFTs)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(NFTServiceServer).GetAptosNFTs(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: NFTService_GetAptosNFTs_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(NFTServiceServer).GetAptosNFTs(ctx, req.(*ReqGetAptosNFTs))
	}
	return interceptor(ctx, in, info, handler)
}

func _NFTService_GetAptosNFTMetadatas_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(ReqGetAptosNFTMetadatas)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(NFTServiceServer).GetAptosNFTMetadatas(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: NFTService_GetAptosNFTMetadatas_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(NFTServiceServer).GetAptosNFTMetadatas(ctx, req.(*ReqGetAptosNFTMetadatas))
	}
	return interceptor(ctx, in, info, handler)
}

func _NFTService_GetAptosNFTsV2_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(ReqGetAptosNFTsV2)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(NFTServiceServer).GetAptosNFTsV2(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: NFTService_GetAptosNFTsV2_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(NFTServiceServer).GetAptosNFTsV2(ctx, req.(*ReqGetAptosNFTsV2))
	}
	return interceptor(ctx, in, info, handler)
}

func _NFTService_GetAptosNFTOwner_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(ReqGetAptosNFTOwner)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(NFTServiceServer).GetAptosNFTOwner(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: NFTService_GetAptosNFTOwner_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(NFTServiceServer).GetAptosNFTOwner(ctx, req.(*ReqGetAptosNFTOwner))
	}
	return interceptor(ctx, in, info, handler)
}

func _NFTService_AdminGetAptosNFTsInCollection_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(ReqAdminGetAptosNFTsInCollection)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(NFTServiceServer).AdminGetAptosNFTsInCollection(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: NFTService_AdminGetAptosNFTsInCollection_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(NFTServiceServer).AdminGetAptosNFTsInCollection(ctx, req.(*ReqAdminGetAptosNFTsInCollection))
	}
	return interceptor(ctx, in, info, handler)
}

func _NFTService_AdminGetCollectionNFTBuyers_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(ReqAdminGetCollectionNFTBuyers)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(NFTServiceServer).AdminGetCollectionNFTBuyers(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: NFTService_AdminGetCollectionNFTBuyers_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(NFTServiceServer).AdminGetCollectionNFTBuyers(ctx, req.(*ReqAdminGetCollectionNFTBuyers))
	}
	return interceptor(ctx, in, info, handler)
}

func _NFTService_AdminGetCollectionNFTOffers_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(ReqAdminGetCollectionNFTOffers)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(NFTServiceServer).AdminGetCollectionNFTOffers(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: NFTService_AdminGetCollectionNFTOffers_FullMethodName,
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(NFTServiceServer).AdminGetCollectionNFTOffers(ctx, req.(*ReqAdminGetCollectionNFTOffers))
	}
	return interceptor(ctx, in, info, handler)
}

// NFTService_ServiceDesc is the grpc.ServiceDesc for NFTService service.
// It's only intended for direct use with grpc.RegisterService,
// and not to be introspected or modified (even as a copy)
var NFTService_ServiceDesc = grpc.ServiceDesc{
	ServiceName: "mpb.NFTService",
	HandlerType: (*NFTServiceServer)(nil),
	Methods: []grpc.MethodDesc{
		{
			MethodName: "GetAptosNFTs",
			Handler:    _NFTService_GetAptosNFTs_Handler,
		},
		{
			MethodName: "GetAptosNFTMetadatas",
			Handler:    _NFTService_GetAptosNFTMetadatas_Handler,
		},
		{
			MethodName: "GetAptosNFTsV2",
			Handler:    _NFTService_GetAptosNFTsV2_Handler,
		},
		{
			MethodName: "GetAptosNFTOwner",
			Handler:    _NFTService_GetAptosNFTOwner_Handler,
		},
		{
			MethodName: "AdminGetAptosNFTsInCollection",
			Handler:    _NFTService_AdminGetAptosNFTsInCollection_Handler,
		},
		{
			MethodName: "AdminGetCollectionNFTBuyers",
			Handler:    _NFTService_AdminGetCollectionNFTBuyers_Handler,
		},
		{
			MethodName: "AdminGetCollectionNFTOffers",
			Handler:    _NFTService_AdminGetCollectionNFTOffers_Handler,
		},
	},
	Streams:  []grpc.StreamDesc{},
	Metadata: "grpc_nft.proto",
}
