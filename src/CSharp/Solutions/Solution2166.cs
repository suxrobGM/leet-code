namespace LeetCode.Solutions;

public class Solution2166
{
    /// <summary>
    /// 2166. Design Bitset - Medium
    /// <a href="https://leetcode.com/problems/design-bitset">See the problem</a>
    /// </summary>
    public class Bitset
    {
        private readonly bool[] _bits;
        private readonly int _size;
        private bool _flipped;   // when true, every stored bit is logically inverted
        private int _ones;       // number of logical 1s currently set

        public Bitset(int size)
        {
            _size = size;
            _bits = new bool[size];
            _flipped = false;
            _ones = 0;
        }

        public void Fix(int idx)
        {
            // Logical value at idx is _bits[idx] ^ _flipped; we want it to be 1.
            if ((_bits[idx] ^ _flipped) == false)
            {
                _bits[idx] = !_bits[idx];
                _ones++;
            }
        }

        public void Unfix(int idx)
        {
            // We want the logical value at idx to be 0.
            if ((_bits[idx] ^ _flipped) == true)
            {
                _bits[idx] = !_bits[idx];
                _ones--;
            }
        }

        public void Flip()
        {
            _flipped = !_flipped;
            _ones = _size - _ones;
        }

        public bool All() => _ones == _size;

        public bool One() => _ones > 0;

        public int Count() => _ones;

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder(_size);
            for (int i = 0; i < _size; i++)
                sb.Append(_bits[i] ^ _flipped ? '1' : '0');
            return sb.ToString();
        }
    }
}
