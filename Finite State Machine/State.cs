using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_State_Machine
{
    /// <summary>
    /// Machine이 가지고 있는 각각의 상태입니다.
    /// </summary>
    public class State
    {
        private static int TotalStateCount = 0;
        private int index;
        private int x;
        private int y;

        /// <summary>
        /// 상태 전이 규칙들의 목록입니다.
        /// </summary>
        public List<Rule> Rules;
        /// <summary>
        /// 현재 상태의 고유 번호입니다.
        /// </summary>
        public int Index
        {
            get { return index; }
        }
        /// <summary>
        /// 화면 상의 X 좌표
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        /// <summary>
        /// 화면 상의 Y 좌표
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// 새로운 상태를 만듭니다.
        /// </summary>
        public State()
        {
            Rules = new List<Rule>();
            index = TotalStateCount;
            TotalStateCount += 1;
        }

        /// <summary>
        /// 해당 상태에 새로운 상태 전이 규칙을 추가합니다.
        /// </summary>
        /// <param name="input">입력값</param>
        /// <param name="nextState">다음 상태</param>
        /// <param name="output">출력값</param>
        /// <returns>현재 상태</returns>
        public State AddRule(char input, int nextState, char output)
        {
            Rules.Add(new Rule(input, nextState, output));

            return this;
        }

        /// <summary>
        /// 주어진 입력값에 대한 출력값을 반환합니다. 해당하는 상태 전이 규칙이 없을 경우 0(NUL)을 반환합니다.
        /// </summary>
        /// <param name="input">입력값</param>
        /// <returns>출력값</returns>
        public char GetOutput(char input)
        {
            foreach (var r in Rules)
            {
                if (r.Input == input)
                {
                    return r.Output;
                }
            }

            return (char)0;
        }

        /// <summary>
        /// 주어진 입력값에 대한 다음 상태를 반환합니다. 해당하는 상태 전이 규칙이 없을 경우 -1을 반환합니다.
        /// </summary>
        /// <param name="input">입력값</param>
        /// <returns>다음 상태</returns>
        public int GetNextState(char input)
        {
            foreach (var r in Rules)
            {
                if (r.Input == input)
                {
                    return r.NextState;
                }
            }

            return -1;
        }

        /// <summary>
        /// 주어진 입력값에 대한 상태 전이 규칙을 반환합니다. 없을 경우 null을 반환합니다.
        /// </summary>
        /// <param name="input">입력값</param>
        /// <returns>상태 전이 규칙</returns>
        public Rule GetRule(char input)
        {
            foreach(var r in Rules)
            {
                if (r.Input == input)
                {
                    return r;
                }
            }

            return null;
        }
    }
}
