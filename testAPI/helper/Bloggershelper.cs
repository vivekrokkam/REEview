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
            String BlogUrl = "blogUrl";


            // Create a new Blogger Object from the model defined in the API.
            Blogger blogger = new Blogger
            {



               // BlogId = blogid,
                Title = title,
                WebUrl = BlogUrl,
                Description = description,
                CreatedDate = published
            };
            return blogger;
            //  return public string Title { get => Title1; set => Title1 = value; }
            // public string Title1 { get => title; set => title = value; }
        }
    }
}
 /*       blogger;
         }
         public static Posts GetPostInfo(int blogId)
         {
             String APIKey = "AIzaSyAv3sIKdSZNafY_ - LVgHah2_tv7q8G5Wkc";
             String bloggerAPIURL = "https://www.googleapis.com/blogger/v3/blogs/"+blogId+"/posts?key=" + APIKey;


             // Use an http client to grab the JSON string from the web.
             String blogInfoJSON = new WebClient().DownloadString(bloggerAPIURL);

             // Using dynamic object helps us to more effciently extract infomation from a large JSON String.
             dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(blogInfoJSON);

             // Extract information from the dynamic object.
             String title = jsonObj.item[0]["title"];
             int postId = jsonObj.item[0]["id"];
             String content = jsonObj.items[0]["content"];


             // Create a new Blogger Object from the model defined in the API.
             Posts posts = new Posts
             {
                 PostsId = postId,
                 BlogId = blogId,
                 Title = title,
                 Content = content
                // CreatedDate = published
             };

             return posts;
         }
         */
