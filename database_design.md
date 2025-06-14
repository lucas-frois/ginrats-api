Table users {
  id uuid [primary key]
  name varchar(100) [not null]
  username varchar(100) [not null]
  email varchar(255) [not null]
  profile_picture_s3_key varchar(255)
  created_at datetime 
  updated_at datetime
}

Table groups {
  id uuid [primary key]
  name varchar(100) [not null]
  description varchar(255)
  code varchar(255) [not null] 
  header_photo_s3_key varchar(255)
  requires_photo bool 
  group_goal_id uuid [not null]
  created_at datetime [not null]
  update_at datetime [null]
  end_date datetime [null]
}

Table group_goals {
  id uuid [primary key]
  name varchar(100)
}

Table group_memberships {
  id uuid [primary key] 
  group_id uuid [not null]
  user_id uuid [not null]
}

Table post_groups {
  id uuid [primary key]
  post_id uuid [not null]
  group_id uuid [not null]
}

Table posts {
  id uuid [primary key]
  user_id uuid [not null]
  drink_name varchar(100) [not null]
  abv_percentage int [not null]
  volume_ml int [not null]
  photo_s3_key varchar(255) [null]
  notes varchar(500) [null]
  created_at datetime
}

Ref: posts.id > post_groups.id
Ref: groups.id > post_groups.id

Ref: group_goals.id > groups.group_goal_id

Ref: groups.id > group_memberships.group_id
Ref: users.id > group_memberships.user_id

