using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jg.Editor
{
   public class NoClassWin:System.Windows.Window
   {
       public NoClassWin()
           : base()
       {

           this.Loaded += delegate
           {

               SetWin();

           };
       }

       public void SetWin()
       {
           FullScreenManager.RepairWpfWindowFullScreenBehavior(this);
       }

   }
}
