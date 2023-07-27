using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace ICare.Business.Commons
{
    public static class GenerateXML
    {
        //Serialize to xml with headers
        public static string Serialize(object dataToSerialize)
        {
            try
            {
                if (dataToSerialize == null)
                    return null;

                using (StringWriter stringwriter = new StringWriter())
                {
                    var serializer = new XmlSerializer(dataToSerialize.GetType());
                    serializer.Serialize(stringwriter, dataToSerialize);
                    return stringwriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //serialize to xml without headers
        public static string ToXML<T>(T obj)
        {
            try
            {
                // Remove Declaration
                var xmlWriterSettings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true,
                };

                // Remove Namespace
                var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, xmlWriterSettings))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, obj, ns);
                    return stream.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //use this method if you don't need "/r/n: in output json without Headers.
        public static string ObjectToXmlString(object objectToConvert)
        {
            try
            {
                string xmlStr = string.Empty;

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = false;
                settings.OmitXmlDeclaration = true;
                settings.NewLineChars = string.Empty;
                settings.NewLineHandling = NewLineHandling.None;

                using (StringWriter stringWriter = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
                    {
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add(string.Empty, string.Empty);

                        XmlSerializer serializer = new XmlSerializer(objectToConvert.GetType());
                        serializer.Serialize(xmlWriter, objectToConvert, namespaces);

                        xmlStr = stringWriter.ToString();
                        xmlWriter.Close();
                    }

                    stringWriter.Close();
                }

                return xmlStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ObjectToXmlStringForProperties(object objectToConvertForProperties)
        {
            try
            {
                string xmlStr = string.Empty;

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = false;
                settings.OmitXmlDeclaration = true;
                settings.NewLineChars = string.Empty;
                settings.NewLineHandling = NewLineHandling.None;

                using (StringWriter stringWriter = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
                    {
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add(string.Empty, string.Empty);

                        XmlSerializer serializer = new XmlSerializer(objectToConvertForProperties.GetType());

                        //serializer.Serialize(xmlWriter, _object, namespaces);

                        xmlStr = stringWriter.ToString();
                        xmlWriter.Close();
                    }

                    stringWriter.Close();
                }

                return xmlStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string PropertiesToXml<T>(T items)
        {
            //Get all the properties
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var xml = "";
            //Create xml string for modal properties.
            foreach (PropertyInfo prop in props)
            {
                var a = prop.GetValue(items);
                xml += "<" + prop.Name + ">" + a + "</" + prop.Name + ">";
            }            
            return xml;
        }
    }
}
