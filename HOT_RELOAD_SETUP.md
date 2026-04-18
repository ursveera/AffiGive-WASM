# Hot Reload Configuration - AffiGive WASM

## ✅ Configuration Complete

Hot reload has been successfully enabled for your Blazor WebAssembly project.

### What Was Changed

1. **WASM.csproj** - Added `<EnableHotReload>true</EnableHotReload>` property
2. **Properties/launchSettings.json** - Added `"DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH": "false"` to all debug profiles

## 🚀 How to Use Hot Reload

### Running with Hot Reload (Recommended)

```powershell
dotnet watch run
```

Or in Visual Studio:
1. Set the startup project to **WASM**
2. Press **F5** or click **Debug → Start Debugging**
3. The application will start and watch for changes

### What Gets Hot Reloaded

✅ **Works with Hot Reload:**
- Component markup (.razor files)
- C# code in code-behind blocks
- CSS styles
- Parameters and properties
- Event handlers
- Local variables and state

❌ **Requires Full Rebuild:**
- NuGet package changes
- Constructor changes
- Method signature changes
- New service registrations in Program.cs
- New page routes
- Dependency injection changes

## 🔄 Hot Reload Features

### Edit & Continue
1. Make changes to your `.razor` file
2. Save the file (Ctrl+S)
3. The browser automatically refreshes with your changes
4. No need to restart the application

### Multiple File Types Supported
- **Razor Components** (.razor)
- **C# Code** (@code blocks)
- **CSS Styles** (<style> blocks)
- **HTML Markup** (component templates)

## ⚙️ Advanced Configuration

### Environment Variables
If you want to disable browser auto-refresh (hot reload still works):
```json
"DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH": "true"
```

### Keyboard Shortcuts
- **Ctrl+S** - Save and trigger hot reload
- **F5** - Full rebuild and reload
- **Shift+F5** - Stop debugging

## 🐛 Troubleshooting

### Hot Reload Not Working?
1. **Check Console Output** - Look for hot reload messages
2. **Clear Browser Cache** - Ctrl+Shift+Delete
3. **Hard Refresh** - Ctrl+Shift+R (Chrome/Edge) or Cmd+Shift+R (Mac)
4. **Full Rebuild** - Clean solution and rebuild

### Compilation Errors?
1. The application will show compilation errors in the browser
2. Fix the error and save
3. The app will automatically update when error is fixed

### Changes Not Reflecting?
- If changes involve constructors or service registration, do a full rebuild
- For CSS changes, do a hard refresh (Ctrl+Shift+R)
- For component logic, ensure you've saved the file

## 📊 Performance Tips

1. **Use Watch Mode** - `dotnet watch run` is most efficient
2. **Avoid Constructor Changes** - Requires full rebuild
3. **Keep Components Small** - Faster hot reload cycles
4. **Use Lazy Loading** - For better development experience

## 🎯 Best Practices

1. **Save Frequently** - Changes apply immediately upon save
2. **Check Browser Console** - For any JavaScript errors
3. **Monitor Output Window** - In VS for hot reload status
4. **Use Chrome DevTools** - For debugging during development

## 📚 Additional Resources

- [Microsoft Docs - Hot Reload](https://learn.microsoft.com/en-us/dotnet/fundamentals/hot-reload)
- [Blazor Hot Reload](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/hot-reload)
- [dotnet watch](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-watch)

---

**Status**: ✅ Hot Reload Enabled and Ready to Use
**Last Updated**: 2024
