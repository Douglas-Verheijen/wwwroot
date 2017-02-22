using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Liquid.Home.UI
{
    public static class NgFormExtensions
    {
        public static MvcHtmlString NgEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData = null)
        {
            var helper = html.LabelFor(expression);
            var editor = html.EditorFor(expression, additionalViewData);
            return MvcHtmlStringWrapper(helper, editor);
        }

        public static MvcHtmlString NgTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData = null)
        {
            var helper = html.LabelFor(expression);
            var editor = html.TextAreaFor(expression, additionalViewData);
            return MvcHtmlStringWrapper(helper, editor);
        }

        public static MvcHtmlString NgSubmit<TModel>(this HtmlHelper<TModel> html)
        {
            var submit = new TagBuilder("input");
            submit.Attributes.Add("type", "submit");
            submit.Attributes.Add("value", "Submit");

            var submitWrapper = new TagBuilder("span");
            submitWrapper.Attributes.Add("class", "form-submit");
            submitWrapper.InnerHtml = submit.ToString();

            var builder = new TagBuilder("div");
            builder.Attributes.Add("class", "form-group");
            builder.InnerHtml = submitWrapper.ToString();

            return new MvcHtmlString(builder.ToString());
        }

        private static MvcHtmlString MvcHtmlStringWrapper(MvcHtmlString helper, MvcHtmlString editor)
        {
            var helperWrapper = new TagBuilder("span");
            helperWrapper.Attributes.Add("class", "form-control-label");
            helperWrapper.InnerHtml = helper.ToHtmlString();

            var editorWrapper = new TagBuilder("span");
            editorWrapper.Attributes.Add("class", "form-control");
            editorWrapper.InnerHtml = editor.ToHtmlString();

            var builder = new TagBuilder("div");
            builder.Attributes.Add("class", "form-group");
            builder.InnerHtml = helperWrapper.ToString() + editorWrapper.ToString();

            return new MvcHtmlString(builder.ToString());
        }
    }
}