using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_State_Machine
{
    /// <summary>
    /// 각 State들이 가지고 있는 상태 전이 규칙입니다. 입력값, 다음 상태, 출력값으로 구성되어 있습니다.
    /// </summary>
    public class Rule
    {
        private char input;
        private int nextState;
        private char output;

        /// <summary>
        /// 입력값
        /// </summary>
        public char Input
        {
            get { return input; }
            set { input = value; }
        }
        /// <summary>
        /// 출력값
        /// </summary>
        public char Output
        {
            get { return output; }
            set { output = value; }
        }
        /// <summary>
        /// 다음 상태
        /// </summary>
        public int NextState
        {
            get { return nextState; }
            set { nextState = value; }
        }

        /// <summary>
        /// 새로운 상태 전이 규칙을 만듭니다.
        /// </summary>
        /// <param name="input">입력값</param>
        /// <param name="nextState">다음 상태</param>
        /// <param name="output">출력값</param>
        public Rule(char input, int nextState, char output)
        {
            this.input = input;
            this.nextState = nextState;
            this.output = output;
        }
    }
}
