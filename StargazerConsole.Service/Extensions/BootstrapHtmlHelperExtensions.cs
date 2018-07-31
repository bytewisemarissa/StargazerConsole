using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using StargazerConsole.Extensions;

namespace System.Web.Mvc.Html
{
    public static class BootstrapHtmlHelperExtensions
    {
        public static IHtmlContent BootstrapTextBoxFor<TModel, TProperty>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            bool isReadOnly = false)
        {
            IHtmlContent input;
            if (isReadOnly)
            {
                input = helper.TextBoxFor(expression, new { @readonly = "readonly", @class = "form-control" });
            }
            else
            {
                input = helper.TextBoxFor(expression, new { @class = "form-control" });
            }

            return BuildStandardControl(helper, expression, input);
        }

        public static IHtmlContent BootstrapTextAreaFor<TModel, TProperty>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            bool isReadOnly = false)
        {
            var label = helper.LabelFor(expression, new { @for = helper.IdFor(expression) });

            IHtmlContent input;
            if (isReadOnly)
            {
                input = helper.TextAreaFor(expression, new { @readonly = "readonly", @class = "form-control" });
            }
            else
            {
                input = helper.TextAreaFor(expression, new { @class = "form-control" });
            }

            return BuildStandardControl(helper, expression, input);
        }

        public static IHtmlContent BootstrapCheckboxFor<TModel>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, bool>> expression,
            bool isReadOnly = false)
        {
            var data = ExpressionMetadataProvider.FromLambdaExpression(expression, helper.ViewData,
                helper.MetadataProvider);

            var labelText = data.Metadata.DisplayName ?? data.Metadata.PropertyName;

            IHtmlContent input;
            if (isReadOnly)
            {
                input = helper.CheckBoxFor(expression, new { @readonly = "readonly", @class = "form-check-input" });
            }
            else
            {
                input = helper.CheckBoxFor(expression, new { @class = "form-check-input" });
            }
            
            var returnWriter = new HtmlContentBuilder();

            returnWriter.AppendHtml("<div class=\"form-check\">");
            returnWriter.AppendHtml("<label class=\"form-check-label\">");
            returnWriter.AppendHtml(input);
            returnWriter.AppendHtml($" {labelText}</label>");
            AppendDescriptionHtml(expression, returnWriter);
            AppendFormGroupDivClose(returnWriter);

            return returnWriter;
        }

        public static IHtmlContent BootstrapRadioButtonGroupFor<TModel, TProperty, TDisplay>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<TProperty, TDisplay> options,
            bool isReadOnly = false,
            string buttonClass = "btn btn-default")
        {
            var classes = isReadOnly ? $"{buttonClass} disabled" : buttonClass;

            var returnWriter = new HtmlContentBuilder();

            AppendFormGroupDivOpen(returnWriter);
            AppendLabelHtml(helper, expression, returnWriter);
            returnWriter.AppendHtml($"<div class=\"btn-group\" data-toggle=\"buttons\" id=\"{helper.IdFor(expression)}InputGroup\">");           
            BuildRadioButtons(helper, expression, options, returnWriter, classes);
            returnWriter.AppendHtml($"</div>");
            AppendDescriptionHtml(expression, returnWriter);
            AppendFormGroupDivClose(returnWriter);
            returnWriter.AppendHtml($"<script type=\"text/javascript\">function {helper.IdFor(expression)}_HandleUpdateFor(){{$('input[name={helper.IdFor(expression)}]:checked').removeAttr('checked');$('label[name={helper.IdFor(expression)}Label)].active').find('input').attr('checked', 'checked');}}</script>");

            return returnWriter;
        }

        private static void BuildRadioButtons<TModel, TProperty, TDisplay>(
            IHtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression, 
            Dictionary<TProperty, TDisplay> options,
            HtmlContentBuilder htmlContentBuilder, string s)
        {
            foreach (var option in options)
            {
                if (Equals(htmlHelper.ValueFor(expression), option.Key))
                {
                    htmlContentBuilder.AppendHtml(
                        $"<label name=\"{htmlHelper.IdFor(expression)}Label\" class=\"{s} active\" onclick=\"{htmlHelper.IdFor(expression)}_HandleUpdateFor();\">");
                }
                else
                {
                    htmlContentBuilder.AppendHtml(
                        $"<label name=\"{htmlHelper.IdFor(expression)}Label\" class=\"{s}\" onclick=\"{htmlHelper.IdFor(expression)}_HandleUpdateFor();\">");
                }

                htmlContentBuilder.AppendHtml(htmlHelper.RadioButtonFor(expression, option.Key));
                htmlContentBuilder.AppendHtml(option.Value.ToString());
                htmlContentBuilder.AppendHtml($"</label>");
            }
        }

        public static IHtmlContent BootstrapButtonActionLink<TModel>(
            this IHtmlHelper<TModel> helper,
            string linkText,
            string actionName,
            string controllerName,
            object routeValues = null,
            bool isEnabled = true,
            string classes = "btn btn-primary",
            IDictionary<string, object> htmlAttributes = null)
        {
            if (htmlAttributes == null)
            {
                htmlAttributes = new Dictionary<string, object>();
            }

            if (!htmlAttributes.ContainsKey("class"))
            {
                if (isEnabled)
                {
                    htmlAttributes["class"] = classes;
                }
                else
                {
                    htmlAttributes["class"] = classes + " disabled";
                }

            }

            return helper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes); ;
        }

        public static IHtmlContent BootstrapDropDownListFor<TModel, TProperty>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectListItems,
            bool isReadOnly = false,
            string description = null)
        {
            IHtmlContent input;
            if (isReadOnly)
            {
                input = helper.DropDownListFor(expression, selectListItems, new { @readonly = "readonly", @class = "form-control" });
            }
            else
            {
                input = helper.DropDownListFor(expression, selectListItems, new { @class = "form-control" });
            }

            return BuildStandardControl(helper, expression, input);
        }

        private static HtmlContentBuilder BuildStandardControl<TModel, TProperty>(
            IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            IHtmlContent inputMarkup)
        {
            var returnWriter = new HtmlContentBuilder();

            AppendFormGroupDivOpen(returnWriter);
            AppendLabelHtml(helper, expression, returnWriter);
            returnWriter.AppendHtml(inputMarkup);
            AppendDescriptionHtml(expression, returnWriter);
            AppendFormGroupDivClose(returnWriter);

            return returnWriter;
        }

        private static void AppendLabelHtml<TModel, TProperty>(
            IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            HtmlContentBuilder builder)
        {
            var label = helper.LabelFor(expression, new { @for = helper.IdFor(expression) });
            builder.AppendHtml(label);
        }

        private static void AppendDescriptionHtml<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> expression, 
            HtmlContentBuilder builder)
        {
            if (!(expression.Body is MemberExpression memberExpresion))
            {
                throw new InvalidOperationException("The expression provided must be a member expression.");
            }

            var description = memberExpresion.Member.GetAttribute<DescriptionAttribute>();

            if (description != null)
            {
                builder.AppendHtml($"<small class=\"text-muted\">{description.Description}</small>");
            }
        }
        
        private static void AppendFormGroupDivOpen(HtmlContentBuilder builder)
        {
            builder.AppendHtml("<div class=\"form-group\">");
        }

        private static void AppendFormGroupDivClose(HtmlContentBuilder builder)
        {
            builder.AppendHtml("</div>");
        }
    }
}
