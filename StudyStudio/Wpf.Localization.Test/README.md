# Wpf.Localization.Test
Check the localization test on the wpf.

1. Add Resources.en-US.resx
2. Change access modifier to public
3. Using in xaml
   - Create namespace
     * xmlns:prop="clr-namespace:Wpf.Localization.Test.Properties" 
   - Display text using x:Static markup extension
4. Using in cs
   - Use static property
     * Properties.Resources.*