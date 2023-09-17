using StarterKit.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Domain.Common
{
    public class ViewModelBase
    {
        public int Id { get; set; }
        //  public string Culture { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public string Tag { get; set; }

    }
}
