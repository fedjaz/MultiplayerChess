using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController
{
    public class Move
    {
        public enum MoveTypes
        {
            Default,
            EnPassant,
            Castling
        }

        public MoveTypes MoveType { get; set; }
        public (int, int) FirstPos { get; set; }
        public (int, int) SecondPos { get; set; }
        public (int, int) SecondaryFirstPos { get; set; }
        public (int, int) SecondarySecondPos { get; set; }

        public Move(MoveTypes moveType, (int, int) firstPos, (int, int) secondPos)
        {
            MoveType = moveType;
            FirstPos = firstPos;
            SecondPos = secondPos;
        }

        public Move(MoveTypes moveType, (int, int) firstPos, (int, int) secondPos, (int, int) secondaryFirstPos)
            : this(moveType, firstPos, secondPos)
        {
            SecondaryFirstPos = secondaryFirstPos;
        }

        public Move(MoveTypes moveType, (int, int) firstPos, (int, int) secondPos, (int, int) secondaryFirstPos, (int, int) secondarySecondPos)
            : this(moveType, firstPos, secondPos, secondaryFirstPos)
        {
            SecondarySecondPos = secondarySecondPos;
        }
    }
}
