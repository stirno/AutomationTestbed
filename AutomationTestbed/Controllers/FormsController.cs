using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomationTestbed.Controllers
{
    public class FormsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AutoComplete()
        {
            return View();
        }

        public ActionResult AutoCompleteData(String q)
        {
            List<Object> data = new List<Object>();

            // Generate a consistent seed based on the characters in the query string
            int seed = 0;
            for (int x = 0; x < q.Length; x++)
            {
                seed += Convert.ToInt32(q[x]);
            }
            System.Random random = new System.Random( seed );

            // Build 5 random "words" of 8 letters
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            for ( int word = 0; word < 5; word++ )
            {
                char ch;
                int mod = 65; // Start with an uppercase letter
                for ( int letter = 0; letter < 8; letter++ )
                {
                    ch = Convert.ToChar( Convert.ToInt32( Math.Floor( 26 * random.NextDouble() + mod ) ) );
                    builder.Append(ch);
                    mod = 97; // Switch to lowercase
                }
                data.Add(new { Name = builder.ToString() });
                builder.Clear();
            }
            
            return Json(data);
        }
    }
}
