#pragma checksum "C:\Users\thehe\OneDrive\Área de Trabalho\New folder\Pokécheck\Pokécheck\Pokécheck\Views\ProcurarPokemon.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3EEE474C554642EB74CD01902AE2A9C1985FD9182C9A95E8ADD5C8D14425B6DC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pokécheck
{
    partial class Procurar_Pokémons : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\ProcurarPokemon.xaml line 12
                {
                    this.pokemonView = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Views\ProcurarPokemon.xaml line 25
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element3).SelectionChanged += this.TextBlock_SelectionChanged;
                }
                break;
            case 4: // Views\ProcurarPokemon.xaml line 26
                {
                    this.ComboBoxMenu = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.ComboBoxMenu).SelectionChanged += this.ComboBoxMenu_SelectionChanged;
                }
                break;
            case 5: // Views\ProcurarPokemon.xaml line 39
                {
                    global::Windows.UI.Xaml.Controls.TextBox element5 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element5).TextChanged += this.TextBox_TextChanged_1;
                }
                break;
            case 6: // Views\ProcurarPokemon.xaml line 49
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Button_Click_1;
                }
                break;
            case 7: // Views\ProcurarPokemon.xaml line 58
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.Button_Click;
                }
                break;
            case 8: // Views\ProcurarPokemon.xaml line 67
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.Button_Click_3;
                }
                break;
            case 9: // Views\ProcurarPokemon.xaml line 76
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.Button_Click_2;
                }
                break;
            case 10: // Views\ProcurarPokemon.xaml line 85
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.FindPokemon;
                }
                break;
            case 11: // Views\ProcurarPokemon.xaml line 108
                {
                    this.pokemonsGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

