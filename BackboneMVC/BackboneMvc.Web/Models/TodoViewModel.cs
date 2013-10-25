using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackboneMvc.Data;

namespace BackboneMvc.Web.Models
{
    public class TodoViewModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool done { get; set; }
        public int order { get; set; }

        public TodoViewModel() { }

        public TodoViewModel(Todo t)
        {
            this.id = t.Id;
            this.text = t.Text;
            this.done = t.Done;
            this.order = t.Order;
        }

    }
}