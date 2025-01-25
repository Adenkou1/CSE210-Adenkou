using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Entry 
    {
        public string Prompt { get; set;}
        public string Response { get; set;}
        public string Date { get; set;}

        public Entry(string Prompt, string Response, string Date)
        {
            Prompt = prompt;
            Response = response;
            Date = Date;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}