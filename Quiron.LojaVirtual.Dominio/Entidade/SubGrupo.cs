﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class SubGrupo
    {
        public int SubGrupoId { get; set; }
        public string GrupoCodigo { get; set; }
        public string SubGrupoCodigo { get; set; }
        public string SubGrupoDescricao { get; set; }
    }
}
