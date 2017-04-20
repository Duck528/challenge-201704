using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_201704
{
    public class UserDTO
    {
        public string Gender { get; set; }
        /// <summary>
        /// 순서대로
        /// title, first, last
        /// </summary>
        public Dictionary<string, string> Name { get; set; }
        /// <summary>
        /// 순서대로
        /// street, city, state, post-code
        /// </summary>
        public Dictionary<string, string> Location { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> Login { get; set; }
        public Dictionary<string, string> Picture { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
    }
}
