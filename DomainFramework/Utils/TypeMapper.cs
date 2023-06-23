using DomainFramework.Exceptions;

namespace DomainFramework.Utils;

public class TypeMapper<TInputType, TOutputType>
{
    private readonly Dictionary<Type, Type> map = new();

    public void DefineMap<TInput, TOutput>()
        where TInput : TInputType
        where TOutput : TOutputType
    {
        var inputType = typeof(TInput);

        if (map.ContainsKey(inputType))
            throw new MapAlreadyDefinedException(inputType);

        map.Add(inputType, typeof(TOutput));
    }

    public Type Map<TInput>()
        where TInput : TInputType
    {
        var inputType = typeof(TInput);

        if (!map.ContainsKey(inputType))
            throw new MapNotDefinedException(inputType);
        
        return map[inputType];
    }
}