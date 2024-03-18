using Autopiter.Core.Enum;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Entities
{
    public class PrintingDevice
    {
        private ConnectionType _connectionType;
        private string? _macAdress;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ConnectionType ConnectionType
        {
            get => _connectionType;
            set => _connectionType = value;
        }

        public string? MacAdress
        {
            get
            {
                if (_connectionType != ConnectionType.Network)
                    _macAdress = null;

                return _macAdress;
            }
            set
            {
                    _macAdress = value;
            }
        }
    }

}
