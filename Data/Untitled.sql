CREATE TABLE [Music] (
  [guid] nvarchar(36) NOT NULL,
  [title] nvarchar(max) NOT NULL,
  [singer] nvarchar(max) NOT NULL,
  [file_size] nvarchar(max) NOT NULL,
  [file_time] nvarchar(max) DEFAULT '' NOT NULL,
  [file_hast] nvarchar(max) NOT NULL,
  [file_id] nvarchar(max) DEFAULT NULL NULL,
  [file_all_path] nvarchar(max) NOT NULL,
  [file_singer] nvarchar(6) NOT NULL,
  [file_image] nvarchar(36) NULL,
  [is_Enable] nvarchar(2) NOT NULL,
  [file_byte] nvarchar(36) NULL,
  CONSTRAINT [_copy_4] PRIMARY KEY CLUSTERED ([guid])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

CREATE TABLE [Music_Song_Sheet] (
  [guid] nvarchar(36) NOT NULL,
  [Music_list_guid] nvarchar(36) NOT NULL,
  [Music_guid] nvarchar(36) NOT NULL,
  CONSTRAINT [_copy_1] PRIMARY KEY CLUSTERED ([guid])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)


CREATE TABLE [MusicByte] (
  [guid] nvarchar(36) NOT NULL,
  [Music_guid] nvarchar(36) NOT NULL,
  [Music_byte] image NOT NULL,
  CONSTRAINT [_copy_6] PRIMARY KEY CLUSTERED ([guid])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)


CREATE TABLE [UserInfo] (
  [guid] nvarchar(36) NOT NULL,
  [user_no] nvarchar(50) NOT NULL,
  [user_pwd] nvarchar(255) NOT NULL,
  [user_Number] nvarchar(50) NULL,
  [user_jurisdiction] nvarchar(1) NOT NULL,
  PRIMARY KEY CLUSTERED ([guid])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)


CREATE TABLE [UserInfo_Music] (
  [guid] nvarchar(36) NOT NULL,
  [UserInfo_guid] nvarchar(36) NOT NULL,
  [Music_guid] nvarchar(36) NOT NULL,
  [ID] nvarchar(max) NOT NULL,
  CONSTRAINT [_copy_5] PRIMARY KEY CLUSTERED ([guid])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)


