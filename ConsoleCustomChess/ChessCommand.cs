using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess
{
    public record ChessCommand(Coord mover, Coord target);
}
