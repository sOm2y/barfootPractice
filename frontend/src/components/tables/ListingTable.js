import React, { useEffect, useState } from 'react'
import { Table, Divider, Tag, Button} from 'antd';
import { getListings } from '../../services/listingService';

const { Column } = Table;


const ListingTable = ({ ...props }) => {
    const [listings, setListings] = useState([])

    useEffect(() => {
        getListings(JSON.parse(localStorage.getItem('token'))).then(res => {
            setListings(res)
        })
    }, [])

    const handleCreate = () => {
        // TODO: Create Listing
    }

    return (
        <React.Fragment>
            <h3>Listing</h3>
            <Button onClick={handleCreate} type="primary" style={{ marginBottom: 16 }}>
                Add a Listing
            </Button>
            <Table rowKey={listing => listing.listingId} dataSource={listings}>

                <Column title="Price" dataIndex="price" key="price" />
                <Column title="Address" dataIndex="address" key="address" />
                <Column title="Created" dataIndex="created" key="created" />
                <Column
                    title="Status"
                    dataIndex="status"
                    key="status"
                    render={status => (
                        <span>

                            <Tag color="blue" >
                                {status}
                            </Tag>

                        </span>
                    )}
                />
                <Column
                    title="Action"
                    key="action"
                    render={(text, record) => (
                        <span>
                            <a href="" onClick={(e) => { }}>Update</a>
                            <Divider type="vertical" />
                            {
                                <a href="" onClick={(e) => { }}>Delete</a>
                            }
                        </span>
                    )}
                />
            </Table>
        </React.Fragment>
    )
}

export default ListingTable