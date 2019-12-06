using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class Informations
    {
        public int          id { get; set; }
        public int          id_log { get; set; }
        public int          id_user { get; set; }
        public string       name { get; set; }
        public string       username { get; set; }
        public string       password { get; set; }
        public string       email { get; set; }
        public string       type { get; set; }
        public string       materie { get; set; }
        public int          grade { get; set; }
        public DateTime     data { get; set; }
        public string       sentence { get; set; }
        public string       answer1 { get; set; }
        public string       answer2 { get; set; }
        public string       answer3 { get; set; }
        public string       answer4 { get; set; }
        public string       right_answer { get; set; }
        public int          question_type { get; set; }
        public int          id_materie { get; set; }
    }
}
