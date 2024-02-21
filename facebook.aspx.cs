using Facebook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jadawelAdmin
{
    public partial class facebook : System.Web.UI.Page
    {
        string access_token = "EAAEWZBXz60HcBABX8K6f5FeIMW0zWFUJQ1klMWMZBSpuWh9WzGVjx9QA5nGvehCPnS2IvGEEhZAqs0V2McPO1a0WDPHERNw9nuvZAZCL7Qs0g6diLoG7KNdmcDVhMAfhlx0ZAZCmGs4ZCY57kZBaZBiBpKNJ4efyNKC6GnHXSZA9zXGOAZDZD";
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckAuthorization();
            //PostToFacebook(access_token);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PostToFacebook(access_token);
            //share_ToFacebook("برنامج جداول", "", 11940);
        }
        private void CheckAuthorization()
        {

            string app_id = "306735776190583";

            string app_secret = "dc00b2bdeb165be8f5b7bacbfd337053";

            string scope = "publish_stream,manage_pages";



            if (Request["code"] == null)
            {

                Response.Redirect(string.Format(

                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",

                    app_id, Request.Url.AbsoluteUri, scope));

            }

            else
            {

                Dictionary<string, string> tokens = new Dictionary<string, string>();



                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",

                    app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);



                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;



                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    StreamReader reader = new StreamReader(response.GetResponseStream());



                    string vals = reader.ReadToEnd();



                    foreach (string token in vals.Split('&'))
                    {

                        tokens.Add(token.Substring(0, token.IndexOf("=")),

                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));

                    }

                }



                string access_token = tokens["access_token"];



                var client = new FacebookClient(access_token);



                client.Post("/me/feed", new { message = "jadawel" });

            }

        }


        public static void PostToFacebook(string pageAccessToken)
        {
            FacebookClient fbClient = new FacebookClient(pageAccessToken);
            fbClient.AppId = "306735776190583";
            fbClient.AppSecret = "dc00b2bdeb165be8f5b7bacbfd337053";
            Dictionary<string, object> fbParams = new Dictionary<string, object>();
            fbParams["message"] = "Test message 2";
            var publishedResponse = fbClient.Post("/jadawelapp/feed", fbParams);
        }

        public void share_ToFacebook(string title, string abbrev, int newsId)
        {
            var postParams = new
            {
                name = title,
                description = abbrev,
                //message = "title",
                link = "http://malekah.info/#/newsDetails/" + newsId,
                picture = "http://api.malekah.info/images/art_images/121016095702.jpg"
            };
            try
            {

                var client = new Facebook.FacebookClient(access_token);

                dynamic res = client.Post("/jadawelapp/feed", postParams);
                string myid = res.id;
                //int m = newsModel.enter_facebook_postid(newsId, myid);

            }

            catch (Exception ex)
            {
                Label1.Text = "Exception during post: " + ex.Message;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var client = new Facebook.FacebookClient(access_token);

            client.Delete("626723004098294_"+TextBox1.Text.Trim());
        }
    }
}