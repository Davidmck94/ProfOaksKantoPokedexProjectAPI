// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace David.IDP;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            //var address = new
            //{
            //    street_address = "One Hacker Way",
            //    locality = "Heidelberg",
            //    postal_code = 69118,
            //    country = "Germany"
            //};
                
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "ProfessorOak",
                    Password = "PalletTown",

                    Claims = new List<Claim>
                    {
                        //new Claim("role", "FreeUser"),
                        new Claim(JwtClaimTypes.GivenName, "Samuel"),
                        new Claim(JwtClaimTypes.FamilyName, "Oak")
                        //new Claim("country", "nl")
                    }
                },
                new TestUser
                {
                    SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "ProfessorElm",
                    Password = "NewBarkTown",

                    Claims = new List<Claim>
                    {
                        //new Claim("role", "PayingUser"),
                        new Claim(JwtClaimTypes.GivenName, "Henry"),
                        new Claim(JwtClaimTypes.FamilyName, "Elm")
                        //new Claim("country", "be")
                    }
                }
            };
        }
    }
}