

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Template.Models;

namespace Template.Models
{
    public class TemplateModel
    {
        [Required(ErrorMessage = "Connection String is required.")]
        public string ConnectionString { get; set; }
        [Required(ErrorMessage = "Table Name is required.")]
        public string TableName { get; set; }
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
        public string TableName => _model.TableName;
        public string ConnectionString => _model.ConnectionString;
    }
}