using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Commands
{
    public class OpenUrlCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is string url)
            {
                Process.Start(url);
            }
        }
    }
}
