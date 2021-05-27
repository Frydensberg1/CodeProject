using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrunkenWizard_SharedProject.Table
{
    public class Language
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string LanguageCode { get; set; }
    }
}
