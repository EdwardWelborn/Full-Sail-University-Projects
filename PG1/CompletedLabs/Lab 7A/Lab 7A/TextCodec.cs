using System.Text;

namespace Lab_7A

{
    public class TextCodec
    {
        public sbyte myOffset { get; set; }

        public TextCodec(sbyte offset)
        {
            myOffset = offset;
        }

        public string Encode(string message)
        {
            var stringBuilder = new StringBuilder(message);
            for (var i = 0; i < message.Length; i++) stringBuilder[i] = (char) (stringBuilder[i] + myOffset);
            return stringBuilder.ToString();
        }

        public string Decode(string message)
        {
            var sb = new StringBuilder(message);
            for (var i = 0; i < message.Length; i++) sb[i] = (char) (sb[i] - myOffset);
            return sb.ToString();
        }
    }
}