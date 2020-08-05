pushd e:\temp
mkdir demo7
cd demo7
svn export https://svn.cc.jyu.fi/srv/svn/ohjdemot/ohj1/s2018/demot/vast/demo7
svn export https://svn.cc.jyu.fi/srv/svn/ohjdemot/ohj1/s2018/demot/vast/demo7Mac
svn export https://svn.cc.jyu.fi/srv/svn/ohjdemot/ohj1/s2018/demot/vast/demo7x51
mkdir demo6
pushd demo6
svn export https://svn.cc.jyu.fi/srv/svn/ohjdemot/ohj1/s2018/demot/vast/demo6/Matriisit
popd
mkdir demo5
pushd demo5
svn export https://svn.cc.jyu.fi/srv/svn/ohjdemot/ohj1/s2018/demot/vast/demo5/Sopulit
popd
zip -r d7 *.*
popd
copy e:\temp\demot\d7.zip
