using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    public class Processor
    {
        private readonly List<IDecoder> decoders;

        private List<KeyValuePair<int, int>> currentMask;
        private Dictionary<long, long> memory = new Dictionary<long, long>();

        public Processor(List<IDecoder> decoders)
        {
            this.decoders = decoders;
        }

        public Dictionary<long, long> GetOutput(List<IProgramLine> lines)
        {
            foreach(var line in lines)
            {
                switch (line)
                {
                    case MaskLine m when line is MaskLine:
                        ProcessMaskLine(m);
                        break;
                    case MemoryLine m when line is MemoryLine:
                        ProcessMemoryLine(m);
                        break;
                    default:
                        break;
                }
            }

            return memory;
        }

        private void ProcessMemoryLine(MemoryLine m)
        {
            foreach (var decoder in decoders)
            {
                var results = decoder.Decode(m, currentMask);

                foreach (var result in results)
                {
                    memory[result.Key] = result.Value;
                }
            }
        }

        private void ProcessMaskLine(MaskLine m)
        {
            currentMask = m.Mask;
        }
    }
}
