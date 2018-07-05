﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExaFinal.Views;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Auth;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ExaFinal.Models;

[assembly: ExportRenderer(typeof(LoginFacebookView),
                          typeof(ExaFinal.Droid.Renderers.LoginFacebookRenderer))]

namespace ExaFinal.Droid.Renderers
{


    public class LoginFacebookRenderer : PageRenderer
    {
        public LoginFacebookRenderer()
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "1583783018411078",
                scope: "",
                authorizeUrl: new Uri(
                    "https://www.facebook.com/v2.8/dialog/oauth"),
                redirectUrl: new Uri(
                    "https://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken =
                        eventArgs.Account.Properties["access_token"].ToString();
                    var profile = await GetFacebookProfileAsync(accessToken);
                    App.LoginFacebookSuccess(profile);
                }
                else
                {
                    App.LoginFacebookFail();
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }

        async Task<FacebookResponse> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl = "https://graph.facebook.com/v2.8/me/?fields=" +
                "name,picture.width(999),cover,age_range,devices,email," +
                "gender,is_verified,birthday,languages,work,website," +
                "religion,location,locale,link,first_name,last_name," +
                "hometown&access_token=" + accessToken;
            var httpClient = new HttpClient();
            var userJson = await httpClient.GetStringAsync(requestUrl);
            var facebookResponse =
                JsonConvert.DeserializeObject<FacebookResponse>(userJson);
            return facebookResponse;
        }
    }

}