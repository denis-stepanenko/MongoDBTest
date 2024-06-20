cls<br/>
show dbs<br/>
use [database]<br/>
show collections<br/>
show users<br/>
db.createCollection([name])<br/>
db.movies.drop()<br/>
db.movies.renameCollection("movies2")<br/>
db.<collection>.insertOne([object])<br/>
db.<collection>.insertMany([[object1], ... , [objectN]]) <br/>
db.<collection>.find()<br/>
db.<collection>.find([filter_object], [fields]) <br/>
	db.movies.find({"genre": "Thriller"}, {"title": 1, "year": 1})<br/>
	db.movies.find({}, {"title": 1})<br/>
db.movies.findOne({"_id": ObjectId("64a2c9842d5edd22c1c126c2")})<br/>
db.movies.countDocuments()<br/>
db.movies.find().limit(5)<br/>
db.movies.find().sort({"title": 1})<br/>
	1 - по возрастанию<br/>
	-1 - по убыванию<br/>
db.movies.find({"year": {$gt: 1950}})<br/>
db.movies.find({"year": {$lt: 1995}})<br/>
db.movies.find({"year": {$lte: 1996}})<br/>
db.movies.find({"year": {$gte: 1996}})<br/>
db.movies.find({"year": {$eq: 2010}})<br/>
db.movies.find({"year": {$ne: 2010}})<br/>
db.movies.find({"year": {$gt: 1960}, "language": "german"})<br/>
db.movies.find({"year": {$lt: 1996, $ne: 1915}})
db.movies.find({$and: [{"year": {$lt: 1996}}, {"year": {$ne: 1915}}]})<br/>
db.movies.find({"year": {$in: [1996, 2009, 2010]}})<br/>
db.movies.find({"year": {$nin: [2009, 2010]}})<br/>
db.movies.find({"genres": "adventure"})<br/>
db.movies.find({"genres": ["adventure", "novel"]})<br/>
db.movies.find({"genres": {$all: ["novel", "adventure"]}})<br/>
db.movies.deleteOne({_id: ObjectId("64a427c36ebe8f8d30934ac9")})<br/>
db.movies.deleteMany({"genres": "drama"})<br/>
db.movies.updateOne({_id: ObjectId("64a4272d6ebe8f8d30934ac8")}, {$set: {"title": "The Little Prince 2"}})<br/>
db.movies.updateMany({"year": {$lt: 2010, $ne: 1915}}, {$set: {"title": "test"}})<br/>
db.movies.updateOne({_id: ObjectId("64a4272d6ebe8f8d30934ac8")}, {$inc: {"year": 2}})<br/>
db.movies.updateOne({_id: ObjectId("64a4272d6ebe8f8d30934ac8")}, {$pull: {"genres": "drama"}})<br/>
db.movies.updateOne({_id: ObjectId("64a4272d6ebe8f8d30934ac8")}, {$push: {"genres": "thriller"}})<br/>
db.movies.updateOne({_id: ObjectId("64a40cca6ebe8f8d30934ac6")}, {$push: {"genres": {$each: ["drama", "novel"]}}})<br/>
db.movies.find({"genres": null, "reviews": null, "language": null})<br/>
db.movies.distinct("year")<br/>
db.movies.find({}, {"genres": {$slice: 1}})<br/>
db.movies.find({}, {"genres": {$slice: -1}})<br/>
version()<br/>
db.hostInfo()<br/>
db.movies.totalSize() / 1024
