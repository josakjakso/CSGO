using Microsoft.AspNetCore.Mvc;

namespace CSGO.Controllers
{
    public class CSGOController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(string input, string Optimization1, string Optimization2, string Optimization3)
        {
            string[] lines = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
            
            for(int i = 0; i < lines.Length; i++) 
            {
                
                int num1;
                int num2;
                string[] words = lines[i].Split(' ');
                if (words.Length == 5)
                {
                    if (Optimization1 != null)
                    {
                        if (words[3].Equals("+"))
                        {
                            num1 = int.Parse(words[2]);
                            num2 = int.Parse(words[4]);
                            lines[i] = words[0] + " " + words[1] + " " + (num1 + num2);
                            

                        }

                    }
                    if (Optimization2 != null)
                    {
                        if (words[3].Equals("*") && words[4].Equals("0"))
                        {
                            lines[i] = words[0] + " " + words[1] + " " + "0";
                           
                        }
                        else if (words[3].Equals("*") && words[4].Equals("1"))
                        {
                            lines[i] = words[0] + " " + words[1] + " " + words[2];
                            
                        }

                    }
                    if (Optimization3 != null)
                    {
                        if (words[3].Equals("*") && words[4].Equals("2"))
                        {
                            lines[i] = words[0] + " " + words[1] + " " + words[2] + " " + "+" + " " + words[2];
                           
                        }
                        if (words[3].Equals("*") && words[4].Equals("4"))
                        {
                            lines[i] = words[0] + " " + words[1] + " " + words[2] + " " + ">>" + " " + "2";
                      
                        }

                    }
                }
                

            }
            string output = string.Join("ㅤㅤㅤㅤㅤㅤ", lines);


            return RedirectToAction("output", new {output = output});
        }


        public IActionResult output(string output) 
        {

            return View("output" , output);
        }
    }
}
