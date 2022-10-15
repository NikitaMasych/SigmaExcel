using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealExcel
{ 
    public class RealVisitor : RealExcelBaseVisitor<decimal>
    {
        private const int leftPart = 0, rightPart = 1;
        public override decimal VisitCompileUnit(RealExcelParser.CompileUnitContext context)
        {
            return Visit(context.expr());
        }
        public override decimal VisitNumber(RealExcelParser.NumberContext context)
        {
            return decimal.Parse(context.GetText());
        }
        public override decimal VisitParenthesis(RealExcelParser.ParenthesisContext context)
        {
            return Visit(context.expr());
        }
        public override decimal VisitAddSub(RealExcelParser.AddSubContext context)
        {
            var left = Visit(context.expr(leftPart));
            var right = Visit(context.expr(rightPart));
            return context.op.Type == RealExcelParser.ADD ? 
                left + right : left - right;
          
        }
        public override decimal VisitMulDiv(RealExcelParser.MulDivContext context)
        {
            var left = Visit(context.expr(leftPart));
            var right = Visit(context.expr(rightPart));
            return context.op.Type == RealExcelParser.MUL ? 
                left * right : left / right;
        }
        public override decimal VisitModIDiv(RealExcelParser.ModIDivContext context)
        {
            var left = (int) Visit(context.expr(leftPart));
            var right = (int) Visit(context.expr(rightPart));
            return (context.op.Type == RealExcelParser.MOD) ? 
                left % right : left / right;
        }
        public override decimal VisitUnary(RealExcelParser.UnaryContext context)
        {
            var value = Visit(context.expr()); ;
            return (context.op.Type == RealExcelParser.SUB)?
                -value : value;
        }
        public override decimal VisitMaxMin(RealExcelParser.MaxMinContext context)
        {
            List<decimal> values = new List<decimal>(10);
            for (int nextIndex = 0; ; ++nextIndex)
            {
                try
                {
                    var nextValue = Visit(context.expr(nextIndex));
                    values.Add(nextValue);
                }
                catch
                {
                    break;
                }
            }
            return context.op.Type == RealExcelParser.MAX ?
                values.Max() : values.Min();
        }
    }
}
