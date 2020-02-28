using System.Collections.Generic;

namespace PrimeiroProjeto.HATEOAS
{
    public class HATEOAS
    {
        private string url;
        private string protocol = "https://";
        public List<Link> actions = new List<Link>();

        public HATEOAS(string url)
        {
            this.url = url;
        }
        public HATEOAS(string url, string protocol)
        {
            this.url = url;
            this.protocol = protocol;
        }

        public void AddAction(string rel, string method)
        {
            // https://localhost:5001/api/vi/produtos
            actions.Add(new Link(this.protocol + this.url, rel, method));
        }

        public Link[] GetActions(string sufix)
        {
            // Link[] tempLinks = actions.ToArray();
            Link[] tempLinks = new Link[actions.Count];
            /* Clonar lista para um array */
            for (int i = 0; i < tempLinks.Length; i++)
            {
                tempLinks[i] = new Link(actions[i].href, actions[i].rel, actions[i].method);
            }

            /* Montagem do link */
            foreach (var link in tempLinks)
            {
                link.href = link.href + "/" + sufix;
            }
            return tempLinks;
        }
    }
}