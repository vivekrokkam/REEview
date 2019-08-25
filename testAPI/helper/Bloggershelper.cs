using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using testAPI.Model;

namespace testAPI.helper
{
    public class Bloggershelper
    {
        public static void testProgram()
        {
            //  Console.WriteLine(GetVideoIdFromURL(""));
            //  AIzaSyAv3sIKdSZNafY_ - LVgHah2_tv7q8G5Wkc
            // Pause the program execution
            Console.WriteLine(GetBlogInfo("https://althouse.blogspot.com/"));
            Console.ReadLine();

        }

        public static Blogger GetBlogInfo(String blogUrl)
        {


            string APIKey = "AIzaSyCoYdGRYle9GBMjeHtYGd2aYx03aWFVQpg";
            String bloggerAPIURL = "https://www.googleapis.com/blogger/v3/blogs/byurl?url=" + blogUrl + "&key=" + APIKey;


            // Use an http client to grab the JSON string from the web.
            String blogInfoJSON = new WebClient().DownloadString(bloggerAPIURL);


            // Using dynamic object helps us to more effciently extract infomation from a large JSON String.
            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(blogInfoJSON);

            // Extract information from the dynamic object.
            string title = jsonObj["name"];
            int blogid = jsonObj["id"];
            String description = jsonObj["url"];
            DateTime published = jsonObj["published"];
          //  GetPostInfo(blogid);



            // Create a new Blogger Object from the model defined in the API.
            Blogger blogger = new Blogger
            {



                PostRefId = blogid,
                Title = title,
                WebUrl = blogUrl,
                Description = description,
                CreatedDate = published
            };

            return blogger;
            //  return public string Title { get => Title1; set => Title1 = value; }
            // public string Title1 { get => title; set => title = value; }
        }



        public static List<Posts> GetPostInfo(int? orgblogId, int blogid)
        {
            String APIKey = "AIzaSyCoYdGRYle9GBMjeHtYGd2aYx03aWFVQpg";
            String bloggerAPIURL = "https://www.googleapis.com/blogger/v3/blogs/" + orgblogId + "/posts?key=" + APIKey;


            // Use an http client to grab the JSON string from the web.
            String blogInfoJSON = new WebClient().DownloadString(bloggerAPIURL);

            // Using dynamic object helps us to more effciently extract infomation from a large JSON String.
            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(blogInfoJSON);

            List<Posts> allPosts = new List<Posts>();

            for (int i = 0; i < jsonObj.items.Count; i++)
            {

                String title = jsonObj["items"][i]["title"];
                String content = jsonObj["items"][i]["content"];

              

                Posts transcription = new Posts
                {
                    Title = title,
                    BlogId = blogid,
                    Content = content
                };
                allPosts.Add(transcription);
            }
            return allPosts;
        }
    }
}
