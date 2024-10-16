using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1darbas
{
    public interface ICardAction
    {
        void PlayCard(int index, Label labelGameMessage, Label playerHandNewCard);
    }
}
