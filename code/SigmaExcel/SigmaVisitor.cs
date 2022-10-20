using System;
using System.Collections.Generic;
using System.Linq;

namespace SigmaExcel
{ 
    public class SigmaVisitor : SigmaExcelBaseVisitor<decimal>
    {
        private const int leftPart = 0, rightPart = 1;
        public override decimal VisitCompileUnit(SigmaExcelParser.CompileUnitContext context)
        {
            return Visit(context.expr());
        }
        public override decimal VisitNumber(SigmaExcelParser.NumberContext context)
        {
            return decimal.Parse(context.GetText());
        }
        public override decimal VisitParenthesis(SigmaExcelParser.ParenthesisContext context)
        {
            return Visit(context.expr());
        }
        public override decimal VisitAddSub(SigmaExcelParser.AddSubContext context)
        {
            var left = Visit(context.expr(leftPart));
            var right = Visit(context.expr(rightPart));
            return context.op.Type == SigmaExcelParser.ADD ? 
                left + right : left - right;
        }
        public override decimal VisitMulDiv(SigmaExcelParser.MulDivContext context)
        {
            var left = Visit(context.expr(leftPart));
            var right = Visit(context.expr(rightPart));
            return context.op.Type == SigmaExcelParser.MUL ? 
                left * right : left / right;
        }
        public override decimal VisitModIDiv(SigmaExcelParser.ModIDivContext context)
        {
            var left = (int) Visit(context.expr(leftPart));
            var right = (int) Visit(context.expr(rightPart));
            return (context.op.Type == SigmaExcelParser.MOD) ? 
                left % right : left / right;
        }
        public override decimal VisitUnary(SigmaExcelParser.UnaryContext context)
        {
            var value = Visit(context.expr()); ;
            return (context.op.Type == SigmaExcelParser.SUB)?
                -value : value;
        }
        public override decimal VisitMaxMin(SigmaExcelParser.MaxMinContext context)
        {
            List<decimal> values = new List<decimal>(10);
            var amountOfExpressions = context.GetText().Length 
                - context.GetText().Replace(",", "").Length + 1;
            for (int i = 0; i != amountOfExpressions; ++i)
            {
                try
                {
                    var nextValue = Visit(context.expr(i));
                    values.Add(nextValue);
                }
                catch
                {
                    throw new Exception("Invalid expression");
                }
            }
            return context.op.Type == SigmaExcelParser.MAX ?
                values.Max() : values.Min();
        }
        public override decimal VisitExponential(SigmaExcelParser.ExponentialContext context)
        {
            var left = (double)Visit(context.expr(leftPart));
            var right = (double)Visit(context.expr(rightPart));
        
            return (decimal)Math.Pow(left, right);
        }
        public override decimal VisitAbs(SigmaExcelParser.AbsContext context)
        {
            return Math.Abs(Visit(context.expr()));
        }
        public override decimal VisitTrigonometrical(SigmaExcelParser.TrigonometricalContext context)
        {
            var value = (double)Visit(context.expr());
            switch (context.op.Type)
            {
                case SigmaExcelParser.SIN:
                    return (decimal)Math.Sin(value);
                case SigmaExcelParser.COS:
                    return (decimal)Math.Cos(value);
                case SigmaExcelParser.TAN:
                    return (decimal)Math.Tan(value);
                case SigmaExcelParser.COT:
                    return (decimal)(1 / Math.Tan(value));
            }
            return base.VisitTrigonometrical(context);
        }
    }
}
