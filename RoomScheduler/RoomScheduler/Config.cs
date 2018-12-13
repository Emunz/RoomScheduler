using System;
using System.Collections.Generic;
using System.Text;

namespace ResSched
{
    public partial class Config
    {

        //These are shared by all environments

        public const string MSALClientId = "7fda6409-a86f-4e4f-8d59-288588dffa46";
        public const string MSALRedirectUri = "msal7fda6409-a86f-4e4f-8d59-288588dffa46://auth";
        public static string[] MSALAuthScopes = { "User.Read" };

        public const string SlackClientId = "21052997777.497846397143";
        public const string SlackClientSecret = "4b5e8aef849a3cac0a0dfec2eba07608";
        public const string SlackRedirectUri = "http://foxbuild.ressched";
        public static string[] SlackScopes = { "users:read" };

#if DEV

        public const string AppCenterUWP = "db62a449-64c8-4063-8039-cf60499c9e55";
        public const string AppCenterAndroid = "07e5dacc-4b03-49ac-99fe-571332935014";
        public const string AppCenteriOS = "af531830-d6c2-4165-bf39-8c07dd6f1895";

#endif

#if QA

        public const string AppCenterUWP = "";
        public const string AppCenterAndroid = "";
        public const string AppCenteriOS = "";

#endif

#if PROD

        public const string AppCenterUWP = "";
        public const string AppCenterAndroid = "";
        public const string AppCenteriOS = "";

#endif


    }
}
