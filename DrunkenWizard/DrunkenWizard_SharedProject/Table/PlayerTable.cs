using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrunkenWizard_SharedProject.Table
{
   public class PlayerTable
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GameKey { get; set; }
        public int GameId { get; set; }
        public bool IsHost { get; set; }
    }
}
