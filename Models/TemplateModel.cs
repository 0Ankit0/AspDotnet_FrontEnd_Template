

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Template.Models;

namespace Template.Models
{
    public class TemplateModel
    {
        public string ControllerName { get; set; }
        public string ControllerType { get; set; }
        public string ControllerPath { get; set; }
        public string ModelPath { get; set; }
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
        public List<ColumnModel> Columns { get; set; }
    }

    public class ColumnModel
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool Exclude { get; set; }
    }
}
namespace Template.Templates
{
    public partial class ModelTemplate
    {
        private TemplateModel _model;
        public ModelTemplate(TemplateModel model)
        {
            _model = model;
        }
        public List<ColumnModel> Columns => _model.Columns;
        public string ControllerName => _model.ControllerName;

    }
    public partial class SelectColumnTemplate
    {
        private TemplateModel _model;
        public SelectColumnTemplate(TemplateModel model)
        {
            _model = model;
        }
        public string TableName => _model.TableName;
        public string ConnectionString => _model.ConnectionString;

    }

    public partial class ControllerTemplate
    {
        private TemplateModel _model;
        public ControllerTemplate(TemplateModel model)
        {
            _model = model;
        }
        public List<ColumnModel> Columns => _model.Columns;
        public string ControllerName => _model.ControllerName;

    }
    public partial class BackendControllerTemplate
    {
        private TemplateModel _model;
        public BackendControllerTemplate(TemplateModel model)
        {
            _model = model;
        }
        public List<ColumnModel> Columns => _model.Columns;
        public string ControllerName => _model.ControllerName;

    }
}