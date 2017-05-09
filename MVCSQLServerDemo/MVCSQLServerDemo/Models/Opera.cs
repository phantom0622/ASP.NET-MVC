using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MVCSQLServerDemo.Models
{
    public class Opera
    {
        [DisplayName("編號")]
        public int OperaID { get; set; }
        [DisplayName("名稱")]
        public string Title { get; set; }
        [DisplayName("年代")]
        public int Year { get; set; }
        [DisplayName("作者")]
        public string Composer { get; set; }
    }
}