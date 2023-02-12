﻿using Dev.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNoticacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
