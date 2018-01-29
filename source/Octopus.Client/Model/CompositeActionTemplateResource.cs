﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Octopus.Client.Extensibility;
using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class CompositeActionTemplateResource : Resource, INamedResource
    {
        readonly IDictionary<string, PropertyValueResource> properties = new Dictionary<string, PropertyValueResource>(StringComparer.OrdinalIgnoreCase);
        readonly IList<ActionTemplateParameterResource> parameters = new List<ActionTemplateParameterResource>();

        [Required(ErrorMessage = "Please provide a name for the template.")]
        [Writeable]
        public string Name { get; set; }

        [Writeable]
        public string Description { get; set; }

        public int Version { get; set; }

        [Writeable]
        public IList<CompositeActionTemplateItemResource> TemplateItems { get; set; }

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public IList<ActionTemplateParameterResource> Parameters
        {
            get { return parameters; }
        }

        public CompositeActionTemplateResource()
        {
            TemplateItems = new List<CompositeActionTemplateItemResource>();
        }
    }
}