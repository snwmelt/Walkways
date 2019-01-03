using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Walkways.MVVM.View.Controls
{
    [ContentProperty( "Text" )]
    [Localizability( LocalizationCategory.Text )]
    public partial class ModernTextBox : TextBox
    {
        #region Dependency Properties

        public static readonly DependencyProperty DisplayPlaceholderTextProperty = DependencyProperty.Register( "DisplayPlaceholderText",
                                                                                                                typeof( Boolean ),
                                                                                                                typeof( ModernTextBox ),
                                                                                                                new PropertyMetadata( false ) );

        public static readonly DependencyProperty PlaceholderBrushProperty = DependencyProperty.Register( "PlaceholderBrush",
                                                                                                          typeof( Brush ),
                                                                                                          typeof( ModernTextBox ),
                                                                                                          new PropertyMetadata( new SolidColorBrush( Colors.Black ) ) );

        public static readonly DependencyProperty PlaceholderOpacityProperty = DependencyProperty.Register( "PlaceholderOpacity",
                                                                                                            typeof( Double ),
                                                                                                            typeof( ModernTextBox ),
                                                                                                            new PropertyMetadata( 1.0 ) );

        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register( "PlaceholderText",
                                                                                                     typeof( String ),
                                                                                                     typeof( ModernTextBox ),
                                                                                                     new PropertyMetadata( "" ) );



        #endregion
        static ModernTextBox( )
        {
            DefaultStyleKeyProperty.OverrideMetadata( typeof( ModernTextBox ), new FrameworkPropertyMetadata( typeof( ModernTextBox ) ) );
        }

        public ModernTextBox( )
        {
            InitializeComponent( );

            Template = ( ControlTemplate )this.Resources[ "ModernTextBoxControlTemplateKey" ];
        }


        public Boolean DisplayPlaceholderText
        {
            get
            {
                return ( Boolean )this.GetValue( DisplayPlaceholderTextProperty );
            }

            set
            {
                this.SetValue( DisplayPlaceholderTextProperty, value );
            }
        }

        public Brush PlaceholderBrush
        {
            get
            {
                return ( Brush )this.GetValue( PlaceholderBrushProperty );
            }

            set
            {
                this.SetValue( PlaceholderBrushProperty, value );
            }
        }

        public Double PlaceholderOpacity
        {
            get
            {
                return ( Double )this.GetValue( PlaceholderOpacityProperty );
            }

            set
            {
                this.SetValue( PlaceholderOpacityProperty, value );
            }
        }

        public String PlaceholderText
        {
            get
            {
                return ( String )this.GetValue( PlaceholderTextProperty );
            }

            set
            {
                this.SetValue( PlaceholderTextProperty, value );
            }
        }



    }
}
