using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using System.Threading;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        #region Commun
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }
        #endregion

        #region Utils
        /// <summary>
        /// Permets de gérer les demandes de requêtes post update delete concernant
        /// un document
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titre"></param>
        /// <param name="image"></param>
        /// <param name="IdRayon"></param>
        /// <param name="IdPublic"></param>
        /// <param name="IdGenre"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public bool utilDocument(string id, string titre, string image, string IdRayon, string IdPublic, string IdGenre, string verbose)
        {
            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", id);
            dicDocument.Add("titre", titre);
            dicDocument.Add("image", image);
            dicDocument.Add("idRayon", IdRayon);
            dicDocument.Add("idPublic", IdPublic);
            dicDocument.Add("idGenre", IdGenre);
            if (verbose == "post")
                return access.CreerEntite("document", JsonConvert.SerializeObject(dicDocument));
            if (verbose == "update")
                return access.UpdateEntite("document", id, JsonConvert.SerializeObject(dicDocument));
            if (verbose == "delete")
                return access.SupprimerEntite("document", JsonConvert.SerializeObject(dicDocument));
            return false;
        }

        /// <summary>
        /// Permets de gérer les demandes de requêtes post update delete concernant
        /// un dvd_livre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public bool utilDvdLivre(string id, string verbose)
        {
            Dictionary<string, string> dicLivreDvd = new Dictionary<string, string>();
            dicLivreDvd.Add("id", id);
            if (verbose == "post")
                return access.CreerEntite("livres_dvd", JsonConvert.SerializeObject(dicLivreDvd));
            if (verbose == "delete")
                return access.SupprimerEntite("livres_dvd", JsonConvert.SerializeObject(dicLivreDvd));
            return false;
        }

        /// <summary>
        /// Permets de gérer les demandes de requêtes post update delete concernant
        /// un livre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isbn"></param>
        /// <param name="auteur"></param>
        /// <param name="collection"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public bool utilLivre(string id, string isbn, string auteur, string collection, string verbose)
        {
            Dictionary<string, string> unLivre = new Dictionary<string, string>();
            unLivre.Add("id", id);
            unLivre.Add("ISBN", isbn);
            unLivre.Add("auteur", auteur);
            unLivre.Add("collection", collection);
            if (verbose == "post")
                return access.CreerEntite("livre", JsonConvert.SerializeObject(unLivre));
            if (verbose == "update")
                return access.UpdateEntite("livre", id, JsonConvert.SerializeObject(unLivre));
            if (verbose == "delete")
                return access.SupprimerEntite("livre", JsonConvert.SerializeObject(unLivre));
            return false;
        }

        /// <summary>
        /// Permets de gérer les demandes de requêtes post update delete concernant
        /// un Dvd
        /// </summary>
        /// <param name="id"></param>
        /// <param name="synopsis"></param>
        /// <param name="realisateur"></param>
        /// <param name="duree"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public bool utilDvd(string id, string synopsis, string realisateur, int duree, string verbose)
        {
            Dictionary<string, object> unDvd = new Dictionary<string, object>();
            unDvd.Add("id", id);
            unDvd.Add("synopsis", synopsis);
            unDvd.Add("realisateur", realisateur);
            unDvd.Add("duree", duree);
            if (verbose == "post")
                return access.CreerEntite("dvd", JsonConvert.SerializeObject(unDvd));
            if (verbose == "update")
                return access.UpdateEntite("dvd", id, JsonConvert.SerializeObject(unDvd));
            if (verbose == "delete")
                return access.SupprimerEntite("dvd", JsonConvert.SerializeObject(unDvd));
            return false;
        }

        /// <summary>
        /// Permets de gérer les demandes de requêtes post update delete concernant
        /// une revue
        /// </summary>
        /// <param name="id"></param>
        /// <param name="periodicite"></param>
        /// <param name="delaiMiseADispo"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public bool utilRevue(string id, string periodicite, int delaiMiseADispo, string verbose)
        {
            Dictionary<string, object> uneRevue = new Dictionary<string, object>();
            uneRevue.Add("id", id);
            uneRevue.Add("periodicite", periodicite);
            uneRevue.Add("delaiMiseADispo", delaiMiseADispo);
            if (verbose == "post")
                return access.CreerEntite("revue", JsonConvert.SerializeObject(uneRevue));
            if (verbose == "update")
                return access.UpdateEntite("revue", id, JsonConvert.SerializeObject(uneRevue));
            if (verbose == "delete")
                return access.SupprimerEntite("revue", JsonConvert.SerializeObject(uneRevue));
            return false;
        }
        #endregion

        #region Onglet Livres
        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// creer un livre dans la BDD
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si oppration valide</returns>
        public bool CreerLivre(Livre livre)
        {
            bool validateur = true;
            if (!utilDocument(livre.Id, livre.Titre, livre.Image, livre.IdRayon, livre.IdPublic, livre.IdGenre, "post"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilDvdLivre(livre.Id, "post"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilLivre(livre.Id, livre.Isbn, livre.Auteur, livre.Collection, "post"))
                validateur = false;
           
            return validateur;
        }

        /// <summary>
        /// modifie un livre dans la bddd
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si oppration valide</returns>
        public bool UpdateLivre(Livre livre)
        {
            bool validateur = true;
            if (!utilDocument(livre.Id, livre.Titre, livre.Image, livre.IdRayon, livre.IdPublic, livre.IdGenre, "update"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilLivre(livre.Id, livre.Isbn, livre.Auteur, livre.Collection, "update"))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// supprime un livre dans la bdd
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si oppration valide</returns>
        public bool SupprimerLivre(Livre livre)
        {
            bool validateur = true;
            if (!utilLivre(livre.Id, livre.Isbn, livre.Auteur, livre.Collection, "delete"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilDvdLivre(livre.Id, "delete"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilDocument(livre.Id, livre.Titre, livre.Image, livre.IdRayon, livre.IdPublic, livre.IdGenre, "delete"))
                validateur = false;

            return validateur;
        }
        #endregion

        #region Onglet DvD
        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// creer un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration valide</returns>
        public bool CreerDvd(Dvd dvd)
        {
            bool validateur = true;
            if (!utilDocument(dvd.Id, dvd.Titre, dvd.Image, dvd.IdRayon, dvd.IdPublic, dvd.IdGenre, "post"))
                validateur = false;
            if (!utilDvdLivre(dvd.Id, "post"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilDvd(dvd.Id, dvd.Synopsis, dvd.Realisateur, dvd.Duree, "post"))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// modifie un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration valide</returns>
        public bool UpdateDvd(Dvd dvd)
        {
            bool validateur = true;
            if (!utilDocument(dvd.Id, dvd.Titre, dvd.Image, dvd.IdRayon, dvd.IdPublic, dvd.IdGenre, "update"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilDvd(dvd.Id, dvd.Synopsis, dvd.Realisateur, dvd.Duree, "update"))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// supprime un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration valide</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            bool validateur = true;
            if (!utilDvd(dvd.Id, dvd.Synopsis, dvd.Realisateur, dvd.Duree, "delete"))
                validateur = false;
            if (!utilDvdLivre(dvd.Id, "delete"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilDocument(dvd.Id, dvd.Titre, dvd.Image, dvd.IdRayon, dvd.IdPublic, dvd.IdGenre, "delete"))
                validateur = false;

            return validateur;
        }
        #endregion

        #region Onglet Revues
        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// creer une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration valide</returns>
        public bool CreerRevue(Revue revue)
        {
            bool validateur = true;
            if (!utilDocument(revue.Id, revue.Titre, revue.Image, revue.IdRayon, revue.IdPublic, revue.IdGenre, "post"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilRevue(revue.Id, revue.Periodicite, revue.DelaiMiseADispo, "post"))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// modifie une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration valide</returns>
        public bool UpdateRevue(Revue revue)
        {
            bool validateur = true;
            if (!utilDocument(revue.Id, revue.Titre, revue.Image, revue.IdRayon, revue.IdPublic, revue.IdGenre, "update"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilRevue(revue.Id, revue.Periodicite, revue.DelaiMiseADispo, "update"))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// supprime une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration valide</returns>
        public bool SupprimerRevue(Revue revue)
        {
            bool validateur = true;
            if (!utilRevue(revue.Id, revue.Periodicite, revue.DelaiMiseADispo, "delete"))
                validateur = false;
            //Thread.Sleep(50) a garder pour passage en ligne de l'api ? (lag);
            if (!utilDocument(revue.Id, revue.Titre, revue.Image, revue.IdRayon, revue.IdPublic, revue.IdGenre, "delete"))
                validateur = false;

            return validateur;
        }
        #endregion

        #region Onglet Parutions
        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }
        #endregion
    }
}
