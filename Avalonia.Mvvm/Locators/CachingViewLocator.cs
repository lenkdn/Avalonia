using System;
using System.Collections.Concurrent;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace Avalonia.Mvvm.Locators;

public class CachingViewLocator : IDataTemplate
{
    private readonly Func<object, Control> _fallbackFactory;
    private readonly ConcurrentDictionary<Type, Type?> _typeCache = [];

    public CachingViewLocator(Func<object, Control>? fallbackFactory = null)
    {
        _fallbackFactory = fallbackFactory
                           ?? (_ => new TextBlock {Text = "View not found!"});
    }

    public Control Build(object? data)
    {
        if (data == null) return new TextBlock {Text = "Null data!"};

        var viewModelType = data.GetType();
        var viewType = _typeCache.GetOrAdd(viewModelType, ResolveViewType);

        if (viewType == null ||
            !typeof(Control).IsAssignableFrom(viewType) ||
            viewType.GetConstructor(Type.EmptyTypes) == null)
            return _fallbackFactory(data);

        try
        {
            var view = (Control) Activator.CreateInstance(viewType)!;
            view.DataContext = data;
            return view;
        }
        catch (Exception ex)
        {
            return new TextBlock {Text = ex.Message};
        }
    }

    public bool Match(object? data)
    {
        if (data == null) return false;

        var type = data.GetType();

        return type.Namespace != null &&
               type.Namespace.Contains("ViewModels");
    }

    private Type? ResolveViewType(Type viewModelType)
    {
        var viewModelTypeName = viewModelType.FullName;

        if (string.IsNullOrWhiteSpace(viewModelTypeName)) return null;

        var viewTypeName = viewModelTypeName.Replace("ViewModel", "View");

        return AppDomain.CurrentDomain.GetAssemblies()
            .Select(assembly => assembly.GetType(viewTypeName))
            .OfType<Type>()
            .FirstOrDefault();
    }
}