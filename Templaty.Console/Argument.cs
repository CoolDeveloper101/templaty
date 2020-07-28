namespace Templaty.console
{
    class Argument
    {
        public readonly string Command;
        public readonly ArgumentType Type;
        public readonly string Value;

        public Argument(string value)
        {
            if (value.StartsWith("--"))
            {
                if (value.Length <= 2)
                {
                    Value = value;
                    Type = ArgumentType.Any;
                }
                else if (value.Contains('='))
                {
                    value = value.Substring(2);
                    Command = value[..value.IndexOf('=')];
                    Value = value[(value.IndexOf('=') + 1)..];
                    Type = ArgumentType.Variable;
                }
                else
                {
                    Command = value.Substring(2);
                    Type = ArgumentType.Option;
                }
            }
            else if (value.StartsWith('-'))
            {
                if (value.Length <= 1)
                {
                    Value = value;
                    Type = ArgumentType.Any;
                }
                else
                {
                    Command = value.Substring(1);
                    Type = ArgumentType.Option;
                }
            }
            else
            {
                Value = value;
                Type = ArgumentType.Any;
            }
        }

        public override string ToString()
        {
            if (Type == ArgumentType.Variable)
                return $"{Command}: {Value}";
            else if (Type == ArgumentType.Option)
                return $"{Type}: {Command}";
            return $"{Type}: {Value}";
        }
    }
}
