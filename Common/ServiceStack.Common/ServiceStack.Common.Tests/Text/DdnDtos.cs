using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Platform.Text;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace ServiceStack.Common.Tests.Text
{
	[DataContract(Namespace = "http://schemas.ddnglobal.com/types/")]
	public class UserPublicView
	{
		/// <summary>
		/// I'm naming this 'Id' instead of 'UserId' as this is dto is 
		/// meant to be cached and we may want to handle all caches generically at some point.
		/// </summary>
		/// <value>The id.</value>
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public UserPublicProfile Profile { get; set; }

		[DataMember]
		public ArrayOfPost Posts { get; set; }
	}

	[Serializable]
	[DataContract(Namespace = "http://schemas.ddnglobal.com/types/")]
	public class UserPublicProfile
	{
		public UserPublicProfile()
		{
			this.FollowerUsers = new List<UserSearchResult>();
			this.FollowingUsers = new List<UserSearchResult>();
			this.UserFileTypes = new ArrayOfString();
		}

		[DataMember]
		public Guid Id
		{
			get;
			set;
		}

		[DataMember]
		public string UserType
		{
			get;
			set;
		}

		[DataMember]
		public string UserName
		{
			get;
			set;
		}

		[DataMember]
		public string FullName
		{
			get;
			set;
		}

		[DataMember]
		public string Country
		{
			get;
			set;
		}

		[DataMember]
		public string LanguageCode
		{
			get;
			set;
		}

		[DataMember]
		public DateTime? DateOfBirth
		{
			get;
			set;
		}

		[DataMember]
		public DateTime? LastLoginDate
		{
			get;
			set;
		}

		[DataMember]
		public long FlowPostCount
		{
			get;
			set;
		}

		[DataMember]
		public int BuyCount
		{
			get;
			set;
		}

		[DataMember]
		public int ClientTracksCount
		{
			get;
			set;
		}

		[DataMember]
		public int ViewCount
		{
			get;
			set;
		}

		[DataMember]
		public List<UserSearchResult> FollowerUsers
		{
			get;
			set;
		}

		[DataMember]
		public List<UserSearchResult> FollowingUsers
		{
			get;
			set;
		}

		///ArrayOfString causes translation error
		[DataMember]
		public ArrayOfString UserFileTypes
		{
			get;
			set;
		}

		[DataMember]
		public string OriginalProfileBase64Hash
		{
			get;
			set;
		}

		[DataMember]
		public string AboutMe
		{
			get;
			set;
		}
	}

	[Serializable]
	[CollectionDataContract(Namespace = "http://schemas.ddnglobal.com/types/", ItemName = "String")]
	public class ArrayOfString : List<string>
	{
		public ArrayOfString() { }
		public ArrayOfString(IEnumerable<string> collection) : base(collection) { }

		//TODO: allow params[] constructor, fails on: 
		//Profile = user.TranslateTo<UserPrivateProfile>()
		public static ArrayOfString New(params string[] ids) { return new ArrayOfString(ids); }
		//public ArrayOfString(params string[] ids) : base(ids) { }
	}

	[Serializable]
	[DataContract(Namespace = "http://schemas.ddnglobal.com/types/")]
	public class UserSearchResult
		: IHasId<Guid>
	{
		[DataMember]
		public Guid Id { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public string UserType { get; set; }

		[DataMember]
		public string UserName { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public string FullName { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public string FirstName { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public string LastName { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public string LanguageCode { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public int FlowPostCount { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public int ClientTracksCount { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public int FollowingCount { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public int FollowersCount { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public int ViewCount { get; set; }

		[DataMember(EmitDefaultValue = false)]
		public DateTime ActivationDate { get; set; }
	}

	[Serializable]
	[CollectionDataContract(Namespace = "http://schemas.ddnglobal.com/types/", ItemName = "Post")]
	public class ArrayOfPost : List<Post>
	{
		public ArrayOfPost() { }
		public ArrayOfPost(IEnumerable<Post> collection) : base(collection) { }

		public static ArrayOfPost New(params Post[] ids) { return new ArrayOfPost(ids); }
	}

	[Serializable]
	[DataContract(Namespace = "http://schemas.ddnglobal.com/types/")]
	public class Post
		: IHasStringId
	{
		public Post()
		{
			this.TrackUrns = new ArrayOfStringId();
		}

		public string Id
		{
			get { return this.Urn; }
		}

		[DataMember]
		public string Urn
		{
			get;
			set;
		}

		[DataMember]
		public DateTime DateAdded
		{
			get;
			set;
		}

		[DataMember]
		public bool CanPreviewFullLength
		{
			get;
			set;
		}

		[DataMember]
		public Guid OriginUserId
		{
			get;
			set;
		}

		[DataMember]
		public string OriginUserName
		{
			get;
			set;
		}

		[DataMember]
		public Guid SourceUserId
		{
			get;
			set;
		}

		[DataMember]
		public string SourceUserName
		{
			get;
			set;
		}

		[DataMember]
		public string SubjectUrn
		{
			get;
			set;
		}

		[DataMember]
		public string ContentUrn
		{
			get;
			set;
		}

		[DataMember]
		public ArrayOfStringId TrackUrns
		{
			get;
			set;
		}

		[DataMember]
		public string Caption
		{
			get;
			set;
		}

		[DataMember]
		public Guid CaptionUserId
		{
			get;
			set;
		}

		[DataMember]
		public string CaptionUserName
		{
			get;
			set;
		}

		[DataMember]
		public string PostType
		{
			get;
			set;
		}

		[DataMember]
		public Guid? OnBehalfOfUserId
		{
			get;
			set;
		}
	}

	[CollectionDataContract(Namespace = "http://schemas.ddnglobal.com/types/", ItemName = "Id")]
	public class ArrayOfStringId : List<string>
	{
		public ArrayOfStringId() { }
		public ArrayOfStringId(IEnumerable<string> collection) : base(collection) { }

		//TODO: allow params[] constructor, fails on: o.TranslateTo<ArrayOfStringId>() 
		public static ArrayOfStringId New(params string[] ids) { return new ArrayOfStringId(ids); }
		//public ArrayOfStringId(params string[] ids) : base(ids) { }
	}


	public enum FlowPostType
	{
		Content,
		Text,
		Promo,
	}

	[TextRecord]
	public class FlowPostTransient 
	{
		public FlowPostTransient()
		{
			this.TrackUrns = new List<string>();
		}

		[TextField]
		public long Id { get; set; }
		[TextField]
		public string Urn { get; set; }
		[TextField]
		public Guid UserId { get; set; }
		[TextField]
		public DateTime DateAdded { get; set; }
		[TextField]
		public DateTime DateModified { get; set; }
		[TextField]
		public Guid? TargetUserId { get; set; }
		[TextField]
		public long? ForwardedPostId { get; set; }
		[TextField]
		public Guid OriginUserId { get; set; }
		[TextField]
		public string OriginUserName { get; set; }
		[TextField]
		public Guid SourceUserId { get; set; }
		[TextField]
		public string SourceUserName { get; set; }
		[TextField]
		public string SubjectUrn { get; set; }
		[TextField]
		public string ContentUrn { get; set; }
		[TextField]
		public IList<string> TrackUrns { get; set; }
		[TextField]
		public string Caption { get; set; }
		[TextField]
		public Guid CaptionUserId { get; set; }
		[TextField]
		public string CaptionSourceName { get; set; }
		[TextField]
		public string ForwardedPostUrn { get; set; }
		[TextField]
		public FlowPostType PostType { get; set; }
		[TextField]
		public Guid? OnBehalfOfUserId { get; set; }
	}

	[DataContract(Namespace = "http://schemas.ddnglobal.com/types/")]
	public class Property
	{
		public Property()
		{
		}

		public Property(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

		[DataMember]
		public string Name
		{
			get;
			set;
		}

		[DataMember]
		public string Value
		{
			get;
			set;
		}

		public override string ToString()
		{
			return this.Name + "," + this.Value;
		}
	}

	[CollectionDataContract(Namespace = "http://schemas.ddnglobal.com/types/", ItemName = "Property")]
	public class Properties
		: List<Property>
	{
		public Properties()
		{
		}

		public Properties(IEnumerable<Property> collection)
			: base(collection)
		{
		}

		public string GetPropertyValue(string name)
		{
			foreach (var property in this)
			{
				if (string.CompareOrdinal(property.Name, name) == 0)
				{
					return property.Value;
				}
			}

			return null;
		}

		public Dictionary<string, string> ToDictionary()
		{
			var propertyDict = new Dictionary<string, string>();

			foreach (var property in this)
			{
				propertyDict[property.Name] = property.Value;
			}

			return propertyDict;
		}
	}

	[DataContract(Namespace = "http://schemas.ddnglobal.com/types/")]
	public class ResponseStatus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseStatus"/> class.
		/// 
		/// A response status without an errorcode == success
		/// </summary>
		public ResponseStatus()
		{
			this.Errors = new List<ResponseError>();
		}

		[DataMember]
		public string ErrorCode { get; set; }

		[DataMember]
		public string Message { get; set; }

		[DataMember]
		public string StackTrace { get; set; }

		[DataMember]
		public List<ResponseError> Errors { get; set; }


		public bool IsSuccess
		{
			get { return this.ErrorCode == null; }
		}
	}

	[DataContract(Namespace = "http://schemas.ddnglobal.com/types/")]
	public class ResponseError
	{
		[DataMember]
		public string ErrorCode { get; set; }
		[DataMember]
		public string FieldName { get; set; }
		[DataMember]
		public string Message { get; set; }
	}

	[DataContract(Namespace = "http://schemas.ddnglobal.com/types/")]
	public class GetContentStatsResponse
		: IExtensibleDataObject
	{
		public GetContentStatsResponse()
		{
			this.Version = 100;
			this.ResponseStatus = new ResponseStatus();

			this.TopRecommenders = new List<UserSearchResult>();
			this.LatestPosts = new List<Post>();
		}

		[DataMember]
		public DateTime CreatedDate { get; set; }

		[DataMember]
		public List<UserSearchResult> TopRecommenders { get; set; }

		[DataMember]
		public List<Post> LatestPosts { get; set; }

		#region Standard Response Properties

		[DataMember]
		public int Version
		{
			get;
			set;
		}

		[DataMember]
		public Properties Properties
		{
			get;
			set;
		}

		public ExtensionDataObject ExtensionData
		{
			get;
			set;
		}

		[DataMember]
		public ResponseStatus ResponseStatus
		{
			get;
			set;
		}

		#endregion
	}
}