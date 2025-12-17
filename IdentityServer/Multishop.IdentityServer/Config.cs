// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Multishop.IdentityServer
{
	public static class Config
	{
		//ApiResource listesi ama sadece okunabilir, foreach ile gezilebilir.
		//IdentityServer'ın kullanacağı API kaynaklarını tuttuğun bir koleksiyondur.
		//Bu API’ye hangi scope’ların erişebileceğini belirler.
		public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
	{
			//“ResourceCatalog” adında bir API kaynağım var.
	new ApiResource("ResourceCatalog"){ Scopes = { "CatalogFullPermission","CatalogReadPermission" }},	//2 adet scope tanımlandı
	new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
	new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
	new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
	new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
	new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

	};
		//Kullanıcı girişinde hangi kullanıcı bilgilerinin token içinde taşınacağını belirler.
		public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
		{
			new IdentityResources.OpenId(),
			new IdentityResources.Email(),
			new IdentityResources.Profile()
		};

		//Bu scope'lar, client'ın hangi yetkileri alacağını temsil eder.
		public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
		{
			//Her scope’a bir açıklama veriyorsun.
			new ApiScope("CatalogFullPermission","Full authority for catalog operations"),  //Tam yetki
			new ApiScope("CatalogReadPermission","Read authority for catalog operations") ,// Sadece okuma yetkisi 
			new ApiScope("DiscountFullPermission","Full authority for discount operations"),
			new ApiScope("OrderFullPermission","Full authority for order operations"),
			new ApiScope("CargoFullPermission","Full authority for cargo operations"),
			new ApiScope("BasketFullPermission","Full authority for basket operations"),


			new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

		};

		public static IEnumerable<Client> Clients => new Client[]
{
    // Ziyaretçi kullanıcı tipi için client tanımı
    new Client
	{
        // Bu client’a verilecek benzersiz kimlik
        ClientId = "MultishopVisitorId",

        // Client’ın görünen adı
        ClientName = "Multishop Visitor User",

        // Bu client'ın giriş şekli: ClientCredentials
        // (Kullanıcı olmadan, uygulama kendi adına token alır)
        AllowedGrantTypes = GrantTypes.ClientCredentials,

        // Token alırken kullanılacak gizli anahtar
        ClientSecrets = { new Secret("multishopsecret".Sha256()) },

        // Bu client’ın erişebileceği izinler (scope)
        AllowedScopes = {  "DiscountFullPermission" }
	},
	//Manager
	new Client
	{
		ClientId="MultishopManagerId",
		ClientName="Multishop Manager User",
		AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
		ClientSecrets={new Secret("multishopsecret".Sha256()) },
		AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
	},

	//Admin
	new Client
	{
		ClientId="MultishopAdminId",
		ClientName="Multishop Admin User",
		AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
		ClientSecrets={new Secret("multishopsecret".Sha256()) },
		AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission" ,"CargoFullPermission","BasketFullPermission",
		IdentityServerConstants.LocalApi.ScopeName,
		IdentityServerConstants.StandardScopes.Email,
		IdentityServerConstants.StandardScopes.Profile,
		IdentityServerConstants.StandardScopes.OpenId},

		  AccessTokenLifetime=600
		//	  AllowOfflineAccess = true,
		//RefreshTokenExpiration = TokenExpiration.Sliding,
		//RefreshTokenUsage = TokenUsage.ReUse

	}

};

	}
}
