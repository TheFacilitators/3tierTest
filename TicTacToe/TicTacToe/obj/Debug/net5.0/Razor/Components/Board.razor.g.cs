#pragma checksum "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da55c4d5a27e703769211e1bb005e0d4013e8e4d"
// <auto-generated/>
#pragma warning disable 1591
namespace TicTacToe.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using TicTacToe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\_Imports.razor"
using TicTacToe.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
using TicTacToe.Helpers;

#line default
#line hidden
#nullable disable
    public partial class Board : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 2 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
  
    var gameStatus = Helper.CalculateGameStatus(values);
    string status;
    if (gameStatus == GameStatus.X_wins)
    {
        status = "Winner: X";
    }
    else if (gameStatus == GameStatus.O_wins)
    {
        status = "Winner: O";
    }
    else if (gameStatus == GameStatus.Draw)
    {
        status = "Draw !";
    }
    else
    {
        char nextPlayer = xIsNext ? 'X' : 'O';
        status = $"Next player: {nextPlayer}";
    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, 
#nullable restore
#line 22 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
         status

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "board");
#nullable restore
#line 25 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
     for (int i = 0; i < 9; i++)
    {
        int squareNumber = i;

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<TicTacToe.Components.Square>(4);
            __builder.AddAttribute(5, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Char>(
#nullable restore
#line 29 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
                      values[squareNumber]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "ClickHandler", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 30 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
                                () => HandleClick(squareNumber)

#line default
#line hidden
#nullable disable
            )));
            __builder.SetKey(
#nullable restore
#line 28 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
                     squareNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseComponent();
#nullable restore
#line 31 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n");
            __builder.OpenElement(8, "button");
            __builder.AddAttribute(9, "class", "btn btn-primary");
            __builder.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 33 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
                                          PlayAgainHandler

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(11, "Play again");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n\r\n\r\n");
            __builder.AddMarkupContent(13, @"<style scoped>
    .board {
        display: grid;
        grid-template-columns: auto auto auto;
        background-color: #0a8efa;
        padding: 10px;
        width: 200px;
        height: 200px;
        border-radius: 10%;
    }
    button {
        border-radius: 10%;
        margin: 10px;
    }
</style>");
        }
        #pragma warning restore 1998
#nullable restore
#line 35 "C:\Users\jodyc\RiderProjects\3tierTest\TicTacToe\TicTacToe\Components\Board.razor"
       
    private bool xIsNext;
    private char[] values = new char[9];
    protected override void OnInitialized()
    {
        InitState();
    }
    private void HandleClick(int i)
    {
        if (values[i] != ' ')
        {
            return;
        }
        bool isGameFinished = Helper.CalculateGameStatus(values) != GameStatus.NotYetFinished;
        if (isGameFinished)
        {
            return;
        }
        bool xToPlay = xIsNext;
        values[i] = xToPlay ? 'X' : 'O';
        xIsNext = !xToPlay;
    }
    private void PlayAgainHandler()
    {
        InitState();
    }
    private void InitState()
    {
        values = new char[9]
        {
        ' ', ' ', ' ',
        ' ', ' ', ' ',
        ' ', ' ', ' '
        };
        xIsNext = true;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
